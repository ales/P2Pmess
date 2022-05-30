using System;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using P2PChat.Models;

namespace P2PChat.Services
{
	public class MessageService
	{
		private AppDbContext db;
        public MessageService(AppDbContext appDbContext)
		{
            db = appDbContext;
		}

		public void NewMessage(Message m)
        {
			m.Username = "ales";
			m.Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            m.Id = Hash(m.Username + m.Text + m.Timestamp);

            db.Messages.Add(m);
            db.SaveChanges();
		}

        public List<Message> GetMessages()
        {
            return db.Messages.ToList();
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

