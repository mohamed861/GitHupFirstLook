using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCD08Lab.Models;

namespace MVCD08Lab.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyContext db;
        public EmployeeController(CompanyContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var emps = db.Employees.Include(w => w.Department).ToList();
            return View(emps);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.depts = new SelectList(db.Departments.ToList(), "DeptId", "DeptName", 1);
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.depts = new SelectList(db.Departments.ToList(), "DeptId", "DeptName", 1);
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = db.Employees.Find(id);
            ViewBag.depts = new SelectList(db.Departments.ToList(), "DeptId", "DeptName", emp.DeptId);
            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.depts = new SelectList(db.Departments.ToList(), "DeptId", "DeptName", emp.DeptId);
                return View(emp);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var emp = db.Employees.Find(id);
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}