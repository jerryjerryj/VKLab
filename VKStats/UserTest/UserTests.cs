using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VKStats.Objs;

namespace UserTest
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void UserConstructor()
        {
            User user = new User("123456");
            Assert.AreEqual(user.id,"123456");   
        }
    }
}
