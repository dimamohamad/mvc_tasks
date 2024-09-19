using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _18_9_2024.Models;

namespace _18_9_2024.Controllers
{
    public class TeachersController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Teachers
        public ActionResult Index()
        {
            return View(db.Teachers.Include(a => a.Courses).ToList());
           
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TeacherName,age")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        // GET: Teachers/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Teacher teacher = db.Teachers.Find(id);
        //    if (teacher == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(teacher);
        //}

public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Fetch the teacher with their courses using Include
            Teacher teacher = db.Teachers.Include(t => t.Courses).FirstOrDefault(t => t.ID == id);

            if (teacher == null)
            {
                return HttpNotFound();
            }

            // Pass a list of courses to the view if you want to show all available courses
            ViewBag.Courses = db.Courses.ToList();

            return View(teacher);
        }
        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,TeacherName,age")] Teacher teacher)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(teacher).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(teacher);
        //}
        // POST: Teachers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TeacherName,Age")] Teacher teacher, int[] selectedCourses)
        {
            if (ModelState.IsValid)
            {
                // Fetch the existing teacher with courses
                var teacherToUpdate = db.Teachers.Include(t => t.Courses).FirstOrDefault(t => t.ID == teacher.ID);

                if (teacherToUpdate != null)
                {
                    // Update basic teacher details
                    teacherToUpdate.TeacherName = teacher.TeacherName;
                    teacherToUpdate.age = teacher.age;

                    // Update the courses associated with the teacher
                    teacherToUpdate.Courses.Clear(); // Clear existing courses
                    if (selectedCourses != null)
                    {
                        foreach (var courseId in selectedCourses)
                        {
                            var course = db.Courses.Find(courseId);
                            if (course != null)
                            {
                                teacherToUpdate.Courses.Add(course);
                            }
                        }
                    }

                    db.Entry(teacherToUpdate).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            // If something fails, reload the course list
            ViewBag.Courses = db.Courses.ToList();
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
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
