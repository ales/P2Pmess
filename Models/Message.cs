using System;
namespace P2PChat.Models
{
	public class Message
	{
        public string Id { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public long Timestamp { get; set; }

        public Message()
		{
		}
	}
}

