using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.Models;


namespace WebApplicationModule3Tp1.Controllers
{
    public class ChatController : Controller
    {
        private static List<Chat> listChat;
        public List<Chat> Chats => listChat ?? (listChat = Chat.GetMeuteDeChats());


        // GET: Chat
        public ActionResult Index()
        {
            return View(Chats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            var chatById = Chats.FirstOrDefault(chat => chat.Id == id);
            return View(chatById);
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            var chatById = Chats.FirstOrDefault(chat => chat.Id == id);
            return View(chatById);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var chatToDelete = Chats.FirstOrDefault(chat => chat.Id == id);
                if (chatToDelete != null)
                {
                    Chats.Remove(chatToDelete);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
