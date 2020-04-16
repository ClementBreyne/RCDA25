using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPChats.Models;

namespace TPChats.Controllers
{
    public class ChatController : Controller
    {
        public List<Chat> listeChat = Chat.GetMeuteDeChats();
        // GET: Chat
        public ActionResult Index()
        {
            
            return View(listeChat);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            Chat ChatDetail = listeChat.FirstOrDefault(i => i.Id == id);
            return View(ChatDetail);
        }

        
        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {

            Chat ChatADelete = listeChat.FirstOrDefault(i => i.Id == id);
                
            return View(ChatADelete);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Chat ChatADelete = listeChat.FirstOrDefault(i => i.Id == id);
                listeChat.Remove(ChatADelete);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
