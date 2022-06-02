using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P2PChat.Models;
using P2PChat.ViewModels;
using P2PChat.Services;


namespace P2PChat.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private AppService app { get; set; }

        public HomeController(AppService messageService)
        {
            this.app = messageService;
        }
        
        public IActionResult Index()
        {
            IndexViewModel vm = new() {
                Messages = app.GetMessages(),
                CurrentUser = app.CurrentUser,
                Peers = app.Peers()
            };
            return View(vm);
        }

        [HttpPost("post")]
        public IActionResult Post(Message m)
        {
            app.NewMessage(m);

            return RedirectToAction("index");
        }
    }
}

