using Iau.NotifCenter.Business.BL;
using Iau.NotifCenter.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iau.NotifCenter.WebUi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetMessageList()
        {
            JsonResult content = new JsonResult();
            var messageList = MessageBL.GetMessagesBySenderId(1);
            //content.Data = (Json(messageList));
            return Json(messageList,JsonRequestBehavior.AllowGet);
        }
    }
}