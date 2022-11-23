using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class EmpController : Controller
    {
        TRAININGEntities db = new TRAININGEntities();
        // GET: Emp
        public ActionResult Index()
        {
            return View(db.EMPs.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);//400
            }
            EMP emp = db.EMPs.Find(id); //search for record in emp table by id
            if (emp==null)
            {
                return HttpNotFound();//404
            }
            return View(emp);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new EMP());
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EMP emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.EMPs.Add(emp);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    if (ex.InnerException != null)
                    {
                        ViewBag.Errormsg = ex.InnerException.InnerException.Message;
                    }
                    return View(emp);
                }
            }
            return View(emp);
        }
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);//400
            }
            EMP emp = db.EMPs.Find(id); //search for record in emp table by id
            if (emp == null)
            {
                return HttpNotFound();//404
            }
            return View(emp);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EMP emp)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry<EMP>(emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex) 
            {
                ViewBag.Error = ex.Message;
                if (ex.InnerException != null)
                {
                    ViewBag.Errormsg = ex.InnerException.InnerException.Message;
                }
                return View(emp);
            }
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);//400
            }
            EMP emp = db.EMPs.Find(id); //search for record in emp table by id
            if (emp == null)
            {
                return HttpNotFound();//404
            }
            //return RedirectToAction("Details",emp);
            return View("Delete",emp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            // TODO: Add update logic here
            //db.Entry<EMP>(emp).State = System.Data.Entity.EntityState.Deleted;
            //db.SaveChanges();
            //return RedirectToAction("Index");
            EMP emp = db.EMPs.Find(id);
            db.EMPs.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}