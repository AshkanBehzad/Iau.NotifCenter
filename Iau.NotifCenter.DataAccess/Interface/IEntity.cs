using Iau.NotifCenter.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iau.NotifCenter.DataAccess.Interface
{
    interface IEntity<T>
    {
        List<T> GetAll();
        int Insert(T entity);
        int Remove(T entity);
        T Get(int id);
        int Update(T oldEntity, T newEntity);
    }
}
