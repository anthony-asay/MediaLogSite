using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MediaLogSite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;



namespace MediaLogSite.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private mediaConsumptionDataEntities db = new mediaConsumptionDataEntities();

        public UsersController()
        {
        }

       
        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(User model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string query = "SELECT * FROM Users WHERE Email = @p0 AND Password = @p1";
            User user = await db.Users.SqlQuery(query, model.Email, model.Password).SingleOrDefaultAsync();
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
                Session["userID"] = user.UserID;
                return RedirectToAction("Details");
        }

        // GET: Users/Details/5
        public ActionResult Details()
        {
            User user = db.Users.Find(System.Web.HttpContext.Current.Session["userID"]);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var userNew = new User { UserName = user.Email, Email = user.Email, Password = user.Password };
                db.Users.Add(userNew);
                db.SaveChanges();
                int idU = userNew.UserID;
                Session["userID"] = userNew.UserID;
                Session.Add("user", user);
                return RedirectToAction("Details");
            }

            // If we got this far, something failed, redisplay form
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit()
        {
            User user = db.Users.Find(System.Web.HttpContext.Current.Session["userID"]);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(user);
        }

        public ActionResult BarGraph()
        {
            User user = db.Users.Find(System.Web.HttpContext.Current.Session["userID"]);
            ViewBag.userId = user.UserID;
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete()
        {
            User user = db.Users.Find(System.Web.HttpContext.Current.Session["userID"]);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}