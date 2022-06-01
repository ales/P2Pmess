using System;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using P2PChat.Models;

namespace P2PChat.Services
{
	public class AppService
	{
		private AppDbContext db;

        public string CurrentUser;



        public AppService(AppDbContext appDbContext)
		{
            db = appDbContext;
            CurrentUser = "ales";
		}

        public void HavePeer(string peer_ip, Client c)
        {
            if (c.Port is null)
                return;

            Peer? p = db.Peers.Find(peer_ip + ":" + c.Port);

            long now = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

            if (p is null)
            {
                db.Peers.Add(new Peer() { IPPort = peer_ip + ":" + c.Port, LastId = c.Id, LastSeen = now });
            }
            else
            {
                p.LastId = c.Id;
                p.LastSeen = now;
            }
            db.SaveChanges();
        }

        public List<Peer> Peers()
        {
            return db.Peers.ToList();
        }

        public void ReceiveMessage(Message m)
        {
            if (db.Messages.Find(m.Id) is null)
            {
                db.Messages.Add(m);
                db.SaveChanges();
            }
        }

		public void NewMessage(Message m)
        {
			m.Username = "ales";
			m.Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
            m.Id = Hash(m.Username + m.Text + m.Timestamp);

            ReceiveMessage(m);

            Broadcast(m);
        }

        public void Broadcast(Message m)
        {
            var http = new HttpClient();
            string path = "/api/message/receive";
            
            var peers = db.Peers.Select(p => p.IPPort).ToArray();

            foreach (var peer in peers)
            {
                http.PostAsJsonAsync("http://" + peer + path, new RemoteMessage() { Message = m, Client = new() { Id = CurrentUser, Port = 5127 } });
            }
        }

        public List<Message> GetMessages()
        {
            return db.Messages.OrderByDescending(m=>m.Timestamp).ToList();
        }

        private string Hash(string pass)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pass,
                salt: Encoding.UTF8.GetBytes("salt_my_message💯"),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 98723,
                numBytesRequested: 256 / 8
            ));

            return hashed;
        }
    }
}

