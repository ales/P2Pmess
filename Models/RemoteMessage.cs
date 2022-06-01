using System;
namespace P2PChat.Models
{
	public class RemoteMessage
	{
        public Message Message { get; set; }
        public Client Client { get; set; }

    }
}

