using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private MemeDbContext db = new MemeDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //MemeDbContext db = new MemeDbContext();

            Meme myMeme = new Meme();
            myMeme.Title = "Here is my meme";
            myMeme.Text = "This isn't a good meme";
            myMeme.Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/183/cache/single-puffin_18377_990x742.jpg";
            myMeme.Genre = "Puffin";
            myMeme.SFW = true;

            db.Memes.Add(myMeme);
            db.SaveChanges();

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(int ID = 1)
        {
            //MemeDbContext db = new MemeDbContext();

            Meme myMeme = db.Memes.Find(ID);

            ViewBag.Message = "Your contact page.";

            return View(myMeme);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveOffOfNew(string Title, string Image, string Text, string Genre, string SFW)
        {
            Meme myMeme = new Meme();

            myMeme.Title = Title;
            myMeme.Text = Text;
            myMeme.Image = Image;
            if (SFW == null)
            {
                myMeme.SFW = false;
            }
            else
            {
                myMeme.SFW = true;
            }
            myMeme.Genre = Genre;

            db.Memes.Add(myMeme);
            db.SaveChanges();


            return RedirectToAction("Contact", new { id = myMeme.ID });
        }
    }
}