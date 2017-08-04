using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iau.NotifCenter.Business.BL;
using System.Diagnostics;

namespace Iau.NotifCenter.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UserCreation()
        {
            //Debug.Write(UserBL.CreateUser("behzad", "chizari", "chizari", "123", true));
            Debug.Write(MessageBL.SubmbitMessage("واحدهای جدید", "توجه توجه برندارید", 1, false));
            Debug.Write(MessageBL.SubmbitMessage("واحدهای جدید", "توجه توجه برندارید", 1, false));
            Debug.Write(MessageBL.ModifyMessage(2,"just title edited"));
            Debug.Write(MessageBL.ModifyMessage(3, "title edited","message edited"));
            Debug.Write(MessageBL.ModifyMessage(4, null , "Just message edited"));
        }
    }
}
