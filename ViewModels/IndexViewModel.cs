using System;
using P2PChat.Models;
namespace P2PChat.ViewModels
{
	public class IndexViewModel
	{
		public List<Message> Messages { get; set; }
		public string CurrentUser { get; set; }
		public List<Peer> Peers { get; set; }

		public string ClassBinding(string name)
        {
			return name == CurrentUser ? "mine" : "";
        }
	}
}

