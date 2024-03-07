using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Crud_Login_Mvc.Models;
namespace Crud_Login_Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        readonly DbServicesContext db=new DbServicesContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View(db.tbl_emp.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            db.tbl_emp.Add(emp);
            int a=db.SaveChanges();
            if (a >= 0)
            {
                return RedirectToAction("Index");   
            }
            else
            {
                ViewBag.SubmitMsg = ("<script>alert('Something Went Wrong')</script>");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var a=db.tbl_emp.Where(model => model.Id == id).FirstOrDefault();
            return View(a);
        }

        [HttpPost]
        public ActionResult Edit(Employee em)
        {
            db.Entry(em).State=EntityState.Modified;
            int a = db.SaveChanges();
            if (a >= 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.EditMsg = ("<script>alert('Something Went Wrong')</script>");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var a = db.tbl_emp.Where(model => model.Id == id).FirstOrDefault();
            return View(a);
        }

        [HttpPost]
        public ActionResult Delete(Employee em)
        {
            db.Entry(em).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if (a >= 0)
            {
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.EditMsg = ("<script>alert('Something Went Wrong')</script>");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var employee = db.tbl_emp.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

    }
}