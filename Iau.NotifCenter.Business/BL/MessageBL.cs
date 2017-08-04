using Iau.NotifCenter.DataAccess.DAL;
using Iau.NotifCenter.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iau.NotifCenter.Business.BL
{
    public class MessageBL
    {
        private static MessageDA messageDA = new MessageDA();
        public static int SubmbitMessage(string title, string text, int senderId, bool isUrgent)
        {
            return messageDA.Insert(new DataAccess.Models.Message()
            {
                Body = text,
                Title = title,
                SenderId = senderId,
                SubmitDateTime = DateTime.Now,
                LastModifiedDateTime = DateTime.Now,
                IsUrgent = isUrgent
            });
        }
        public static int ModifyMessage(int id, string newTitle, string newBodyText = null)
        {
            return messageDA.Update(messageDA.Get(id),
                new DataAccess.Models.Message()
                {
                    Body = newBodyText,
                    Title = newTitle,
                    LastModifiedDateTime = DateTime.Now,
                });
        }

        public static List<Message> GetMessagesBySenderId(int senderId)
        {
            return messageDA.GetAll().Where(m => m.SenderId == senderId).OrderByDescending(d => d.SubmitDateTime).ToList();
        }
    }
}
