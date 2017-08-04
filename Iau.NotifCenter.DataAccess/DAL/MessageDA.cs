using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iau.NotifCenter.DataAccess.Interface;
using Iau.NotifCenter.DataAccess.Models;
using Iau.NotifCenter.DataAccess.Helper;

namespace Iau.NotifCenter.DataAccess.DAL
{
    public class MessageDA : IEntity<Message>
    {
        private static NotifCenterContext _db = new NotifCenterContext();

        public Message Get(int id)
        {
            try
            {
                return _db.Message.FirstOrDefault(u => u.Id == id);
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return null;
            }
        }

        public List<Message> GetAll()
        {
            try
            {
                return _db.Message.ToList();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public int Insert(Message entity)
        {

            try
            {
                _db.Message.Add(entity);
                _db.SaveChanges();
                return entity.Id;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return -1;
            }
        }

        public int Remove(Message entity)
        {
            try
            {
                _db.Message.Remove(entity);
                _db.SaveChanges();
                return 0;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return -1;
            }
        }

        public int Update(Message oldEntity, Message newEntity)
        {

            try
            {

                var oldMessage = _db.Message.FirstOrDefault(u => u.Id == oldEntity.Id);
                oldMessage.Body = (!string.IsNullOrEmpty(newEntity.Body)) ? newEntity.Body : oldEntity.Body;
                oldMessage.LastModifiedDateTime = newEntity.LastModifiedDateTime;
                oldMessage.Title = (!string.IsNullOrEmpty(newEntity.Title)) ? newEntity.Title : oldEntity.Title;
                _db.Entry(oldEntity).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return 0;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return -1;
            }
        }
    }
}
