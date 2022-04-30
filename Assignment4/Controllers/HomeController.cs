using System;
using System.Web.Mvc;
using Assignment4.Models;
using System.Data;
using System.Data.Entity;
using System.Collections;
using System.Linq;


namespace Assignment4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        MyDbContext context = new MyDbContext();
        public ActionResult Index()
        {
            MyDbContext context = new MyDbContext();
            return View(context.Accounts);
        }
        public ActionResult CreateAccount(Account a)
        {
            MyDbContext context = new MyDbContext();
            context.Accounts.Add(a);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int? accno)
        {
            MyDbContext context = new MyDbContext();
            var account_to_edit = (from a in context.Accounts where a.AccountNumber == accno select a).SingleOrDefault();
            return View(account_to_edit);
        }
        public ActionResult EditAccount(Account a)
        {
            context.Entry<Account>(a).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? accno)
        {
            var account_to_delete = (from a in context.Accounts
                                     where a.AccountNumber == accno
                                     select a).SingleOrDefault();
            context.Entry<Account>(account_to_delete).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //[ChildActionOnly]
        public ActionResult GetNews(string category)
        {
            return PartialView(null, category);
        }



    }
}