using Iau.NotifCenter.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iau.NotifCenter.DataAccess.Interface;
using Iau.NotifCenter.DataAccess.Helper;

namespace Iau.NotifCenter.DataAccess.DAL
{
    public class UserDA : IEntity<User>
    {
        private static NotifCenterContext _db;
        public UserDA()
        {
            _db = new NotifCenterContext();
        }
        public User Get(int id)
        {
            try
            {
               return _db.User.FirstOrDefault(u => u.Id == id);
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return null;
            }
        }

        public List<User> GetAll()
        {
            try
            {
                return _db.User.ToList();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public int Insert(User entity)
        {
            try
            {
                _db.User.Add(entity);
                _db.SaveChanges();
                return entity.Id;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return -1;
            }
        }

        public int Remove(User entity)
        {
            try
            {
                _db.User.Remove(entity);
                _db.SaveChanges();
                return 0;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return -1;
            }
        }

        public int Update(User oldEntity, User newEntity)
        {
            try
            {

                var oldUser = _db.User.Find(oldEntity);
                oldUser.FirstName = (!string.IsNullOrEmpty( newEntity.FirstName)) ? newEntity.FirstName : oldEntity.FirstName;
                oldUser.LastName = (!string.IsNullOrEmpty(newEntity.LastName)) ? newEntity.LastName : oldEntity.LastName;
                oldUser.Password = (!string.IsNullOrEmpty(newEntity.Password)) ? newEntity.Password : oldEntity.Password;
                oldUser.Username = (!string.IsNullOrEmpty(newEntity.Username)) ? newEntity.Username : oldEntity.Username;
                //oldUser.UserCreatedDateTime = newEntity.UserCreatedDateTime;
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
