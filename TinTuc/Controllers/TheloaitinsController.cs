using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TinTuc.Models;

namespace TinTuc.Controllers
{
    public class TheloaitinsController : Controller
    {
        private TinTucContext db = new TinTucContext();

        // GET: Theloaitins
        public ActionResult Index()
        {
            return View(db.Theloaitins.ToList());
        }

        // GET: Theloaitins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theloaitin theloaitin = db.Theloaitins.Find(id);
            if (theloaitin == null)
            {
                return HttpNotFound();
            }
            return View(theloaitin);
        }

        // GET: Theloaitins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Theloaitins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Maloai,Tentheloai")] Theloaitin theloaitin)
        {
            var kq = db.Theloaitins.FirstOrDefault(x => x.Maloai == theloaitin.Maloai);
            if (db.Theloaitins.FirstOrDefault(x => x.Maloai == theloaitin.Maloai) != null)
            {
                Response.Write("<script>alert('Mã đã tồn tại');</script>");
                return View(theloaitin);
            }

            if (ModelState.IsValid)
            {
                db.Theloaitins.Add(theloaitin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theloaitin);

        }

        // GET: Theloaitins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theloaitin theloaitin = db.Theloaitins.Find(id);
            if (theloaitin == null)
            {
                return HttpNotFound();
            }
            return View(theloaitin);
        }

        // POST: Theloaitins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maloai,Tentheloai")] Theloaitin theloaitin)
        {
            if (String.IsNullOrEmpty(theloaitin.Tentheloai))
            {
                Response.Write("<script>alert('Tên thể loại không được để trống');</script>");
                return View(theloaitin);
            }
            if (ModelState.IsValid)
            {
                db.Entry(theloaitin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theloaitin);
        }

        // GET: Theloaitins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theloaitin theloaitin = db.Theloaitins.Find(id);
            if (theloaitin == null)
            {
                return HttpNotFound();
            }
            return View(theloaitin);
        }

        // POST: Theloaitins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Theloaitin theloaitin = db.Theloaitins.Find(id);
            db.Theloaitins.Remove(theloaitin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
