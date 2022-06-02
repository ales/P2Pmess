using System;
using System.Timers;
using P2PChat;
using P2PChat.Models;

namespace P2PChat.Services
{
	public class TimerService
	{
		private System.Threading.Timer t;

		public TimerService()
		{
			t = new(myEvent, null, 1000, 30000);
		}

		void myEvent(object state)
		{
			new HttpClient().PostAsJsonAsync("http://192.168.3.147:5000/api/ping", new Client() { Id = "ales", Port = 5127 });
		}
	}
}

