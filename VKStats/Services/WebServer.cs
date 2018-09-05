using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
namespace VKStats.Services
{
    class WebServer : Service
    {
        public WebServer()
        {
            Console.WriteLine("This is an imitation of Web-service.\nPress Enter to start\n");
            Console.ReadKey();
            Console.WriteLine("User 123 without friends\nPress any key to continue\n");
            Create("123 false");
            Console.ReadKey();
            Console.WriteLine("User 456 with friends\nPress any key to end\n");
            Create("456 true");
            Console.ReadKey();


        }
        private void Create(string msg)
        {
            var transaction = new MessageQueueTransaction();
            try
            {
                transaction.Begin();
                if (!MessageQueue.Exists(@".\private$\newUser"))
                {
                    MessageQueue.Create(@".\private$\newUser");
                }

                var queue = new MessageQueue(@".\private$\newUser");
                queue.Send(msg, transaction);

                transaction.Commit();
            }
            catch (MessageQueueException ex)
            {
                transaction.Abort();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
