using System;
using Microsoft.EntityFrameworkCore;
using P2PChat.Models;

namespace P2PChat
{
	public class AppDbContext : DbContext
	{
		public DbSet<Message> Messages { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
	}
}

