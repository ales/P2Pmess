using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P2PChat.Models;
using P2PChat.Services;

namespace P2PChat.Controllers
{
    [Route("api")]
    public class ApiController : Controller//Base
    {
        public AppService app { get; set; }
        public ApiController(AppService messageService)
        {
            this.app = messageService;
        }

        [HttpGet("peers")]
        public IActionResult Peers()
        {
            return Ok(app.Peers().Select(p => p.IPPort).ToArray());
        }

        [HttpPost("message/receive")]
        public IActionResult Receive([FromBody] RemoteMessage remoteMessage)
        {
            var peerIp = HttpContext.Connection.RemoteIpAddress.ToString();

            app.ReceiveMessage(remoteMessage.Message);
            app.HavePeer(peerIp, remoteMessage.Client);

            return Ok();
        }

        [HttpPost("ping")]
        public IActionResult Ping([FromBody] Client client)
        {
            var peerIp = HttpContext.Connection.RemoteIpAddress.ToString();

            app.HavePeer(peerIp, client);

            return Ok();
        }
    }
}

