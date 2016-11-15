using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Meme // Aka Session 2
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string Genre { get; set; }
        public bool SFW { get; set; }
    }

    public class MemeDbContext : DbContext
    {
        public DbSet<Meme> Memes { get; set; }
    }
}