using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.Threading;

using VKStats.Base.Params;
using VKStats.Base.Selections;
using VKStats.Base.Transactions;
namespace VKStats.Services
{
    class MainServer : Service
    {
        public MainServer()
        {
            Console.WriteLine("Press any key to start SERVER");
            Console.ReadKey();
            var minUpdate = new SelectDBMinUpdate().Execute(null);
            Console.WriteLine("Last update: " + minUpdate.Value + "\n");
            if (minUpdate <= DateTime.Now.Date)
            {
                Update();
            }
            Console.WriteLine("-+-+-+-+-Start passive mode-+-+-+-+-\n\n Waiting for messages...");
            AnswerMessages();

        }
        private void Update()
        {
            Console.WriteLine("Updating users...");
            UpdUsers(GetUsers());
            WaitForFullUserUpdate(10000);
            Console.WriteLine("Collecting ratings...");
            var number = new SelectNumberOfArtists().Execute(null);
            UpdArtists(number.Value);
            Console.WriteLine("End of update.\n\n");
        }
        private void WaitForFullUserUpdate(int time)
        {
            var minUpdate = new SelectDBMinUpdate().Execute(null);
            while (minUpdate < DateTime.Now.Date)
            {
                Console.Write("☼");
                Thread.Sleep(time);
                minUpdate = new SelectDBMinUpdate().Execute(null);
            }
        }
        private List<string> GetUsers()
        {
            var dataParams = new DateParams
            {
                Date = GetToday()
            };
            return new SelectUpdatableUsers().Execute(dataParams);
        }
        private void UpdUsers(List<string> users)
        {
            var transaction = new MessageQueueTransaction();
            try
            {
                transaction.Begin();
                if (!MessageQueue.Exists(@".\private$\users"))
                {
                    MessageQueue.Create(@".\private$\users");
                }

                var queue = new MessageQueue(@".\private$\users");
                foreach(var user in users)
                    queue.Send(user, transaction);

                transaction.Commit();
            }
            catch (MessageQueueException ex)
            {
                transaction.Abort();
                Console.WriteLine(ex.Message);
            }
        }
        private void UpdArtists(int size)
        {
            var transaction = new MessageQueueTransaction();
            try
            {
                transaction.Begin();
                if (!MessageQueue.Exists(@".\private$\artists"))
                {
                    MessageQueue.Create(@".\private$\artists");
                }

                var queue = new MessageQueue(@".\private$\artists");
                for (int i = 1; i <= size;++i )
                    queue.Send(i.ToString(), transaction);

                transaction.Commit();
            }
            catch (MessageQueueException ex)
            {
                transaction.Abort();
                Console.WriteLine(ex.Message);
            }
        }

        private void AnswerMessages()
        {
            var queue = new MessageQueue(@".\private$\newUser");
            queue.Formatter = new XmlMessageFormatter(new String[] { "System.String" });
            while (true)
            {
                var transaction = new MessageQueueTransaction();
                try
                {
                    transaction.Begin();
                    string message = queue.Receive(transaction).Body.ToString();
                    Console.Write("Recieved : " + message + " ... ");
                    
                    var messageSplitted = message.Split(' ');
                    string userId = messageSplitted[0];
                    if (messageSplitted[1] == "false")
                        new UsersToDataBase(userId).AddUser();
                    else
                        new UsersToDataBase(userId).AddUserWithFriends();
                    Console.WriteLine("DONE");
                    transaction.Commit();
                    Update();
                }
                catch (Exception e)
                {
                    transaction.Abort();
                }
            }
        }
    }
}
