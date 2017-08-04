using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iau.NotifCenter.DataAccess.Helper
{
    public class ExceptionHelper
    {
        public static string AppendInnerExceptions(Exception exception)
        {
            var exc = exception;
            var message = exception.Message;
            while (exc.InnerException != null)
            {
                exc = exc.InnerException;
                message += $" {exc.Message} -> ";
            }
            return message;
        }
    }
}
