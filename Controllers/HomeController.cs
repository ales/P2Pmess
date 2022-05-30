using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P2PChat.Models;
using P2PChat.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2PChat.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private MessageService messageService { get; set; }

        public HomeController(MessageService messageService)
        {
            this.messageService = messageService;
        }
        
        public IActionResult Index()
        {
            return View(messageService.GetMessages());
        }

        [HttpPost("post")]
        public IActionResult Post(Message m)
        {
            messageService.NewMessage(m);

            return RedirectToAction("index");
        }
    }
}

