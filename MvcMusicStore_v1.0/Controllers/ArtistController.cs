using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore_v1._0.Controllers
{
    public class ArtistController : Controller
    {
        private MvcMusicStoreEntities db = new MvcMusicStoreEntities();
        private static int order = 1;

        //
        // GET: /Artist/

        public ActionResult Index()
        {
            return View(db.Artists.ToList());
        }


        //
        // GET: /Artist/Details/5

        public ActionResult Details(int id = 0)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        public ActionResult OrderArtistDetails(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View("OrderArtistDetails", artist);
        }

        //
        // GET: /Artist/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Artist/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        //
        // GET: /Artist/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // POST: /Artist/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        //
        // GET: /Artist/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // POST: /Artist/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}