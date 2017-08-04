using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iau.NotifCenter.DataAccess.Helper
{
    public class LogHelper
    {
        public static bool WriteExceptionLog(Exception exception)
        {
            var message = "-----------------------------------------------" +
                $"Date : {DateTime.Now.ToString()}" +
                $"Message : {ExceptionHelper.AppendInnerExceptions(exception)}" +
                $"Stack Trace : {exception.StackTrace}";

            var path = AppDomain.CurrentDomain.BaseDirectory + "Exception.txt";
            try
            {
                if (!File.Exists(path)) File.Create(path);
                using (FileStream fs = new FileStream(path, FileMode.Append))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(message);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
