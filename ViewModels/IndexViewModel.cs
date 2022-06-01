using System;
using P2PChat.Models;
namespace P2PChat.ViewModels
{
	public class IndexViewModel
	{
		public List<Message> Messages { get; set; }
		public string CurrentUser { get; set; }

		public string ClassBinding(string name, string name2)
        {
			return name == name2 ? "mine" : "";
        }
	}
}

