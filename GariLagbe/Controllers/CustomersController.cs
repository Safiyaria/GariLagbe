using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using GariLagbe.Models;

namespace GariLagbe.Controllers
{
    public class CustomersController : Controller
    {
        private garilagbeEntities db = new garilagbeEntities();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        ///////////////////////////////////////////////////////////// GET: Customers/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Customer_ID,Customer_Name,Customer_Email,Customer_PhoneNO,Customer_Address,Customer_Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        ////////////////////////////////////////////////////////////////////////// GET: Customers/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]


        ///////////////////////////////////////////////////////////// GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Vehicles");
        }


        ///////////////////////////////////////////////////////////////////////signup
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SignUp(Customer ct)
        {

            if (ModelState.IsValid)
            {
                db.Customers.Add(ct);
                db.SaveChanges();
                ViewBag.Success = "Successfully registered";
            }
            else
            {
                ViewBag.Failed = "Registration failed! Please try again";
            }
            ModelState.Clear();
            return View();
        }




        //////////////////////////////////////////////////////////////////////log in

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(TempCustomer tempCustomer)
        {
            if (ModelState.IsValid)
            {
                var customer = db.Customers.Where(c => c.Customer_Name.Equals(tempCustomer.Customer_Name)
                                && c.Customer_Email.Equals(tempCustomer.Customer_Email)
                                && c.Customer_Password.Equals(tempCustomer.Customer_Password)).FirstOrDefault();
                
                if (customer != null)
                { 
                    FormsAuthentication.SetAuthCookie((string)tempCustomer.Customer_Name, false);
                    Session["CustomerName"] = customer.Customer_Name;
                    Session["CustomerEmail"] = customer.Customer_Email;
                    Session["type"] = "Customer";
                    return RedirectToAction("AdminView");
                    //return RedirectToAction("", "Index");
                    //return Content("Login Successful!");


                }
                else
                {
                    ViewBag.Failed = "Login Failed! Please try again";
                    return View();
                }
            }
            return View();
        }




        [HttpGet]
        public ActionResult CustomerProfile()
        {
            String email = Convert.ToString(Session["CustomerEmail"]);
            var customer = db.Customers.Where(u => u.Customer_Email.Equals(email)).FirstOrDefault();
            return View(customer);
        }



        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Vehicles");

        }


        public ActionResult CustomerList()
        {
            return View(db.Customers.ToList());
        }


        public ActionResult ADelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        /// <summary>
        /// ////////////////////////////////////////////////////////////////POST: Customers/Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ADeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("CustomerList", "Customers");
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
