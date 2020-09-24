
using ABCFOODCATERING.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCFoodCatering.Controllers
{
    public class HomeController : Controller
    {
        // GET: List
        DataContext db = new DataContext();
        public ActionResult List()
        {
            // If Session is valid
            if (Session["CustomerID"] != null)
            {
                var data = db.ORDERTABLE.SqlQuery("SELECT * FROM ORDERTABLE").ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

       

        // Post: Home
        [HttpPost]
        public ActionResult Index(CustomerLogin login)
        {
            try
            {
                // Create a new list to store details of new login
                List<object> newLogin = new List<object>();
                newLogin.Add(login.CustomerID);
                newLogin.Add(login.Password);

                // Copy login items into an array for easy addition into SQL statement
                object[] loginItems = newLogin.ToArray();
                var data = db.CUSTOMERLOGINTABLE.SqlQuery("SELECT * FROM CUSTOMERLOGINTABLE WHERE CustomerID=@p0 AND Password=@p1", loginItems).SingleOrDefault();

                // If login successful
                if (data != null)
                {
                    Session["CustomerID"] = login.CustomerID.ToString(); //set session
                    return RedirectToAction("List");
                }
                else
                {
                    ViewBag.msg = "Customer ID and/or Password is invalid";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            // If session is valid
            if (Session["CustomerID"] != null)
            {
                var data = db.ORDERTABLE.SqlQuery("SELECT * FROM ORDERTABLE WHERE OrderID=@p0", id).SingleOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            // If session is valid
            if (Session["CustomerID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Order collection)
        {
            // If session is valid
            if (Session["CustomerID"] != null)
            {
                try
                {
                    // TODO: Add insert logic here
                    List<object> newRecord = new List<object>();
                    newRecord.Add(collection.OrderID);
                    newRecord.Add(collection.FoodDescription);
                    newRecord.Add(collection.DeliveryAddress);
                    newRecord.Add(collection.DeliveryDate);
                    newRecord.Add(collection.DeliveryTime);
                    newRecord.Add(collection.EmailAddress);
                    newRecord.Add(collection.ContactNumber);
                    newRecord.Add(collection.OrderStatus);

                    object[] recordItems = newRecord.ToArray();
                    int result = db.Database.ExecuteSqlCommand("INSERT INTO ORDERTABLE " +
                        "(OrderID, FoodDescription, DeliveryAddress, DeliveryDate, DeliveryTime, EmailAddress, ContactNumber, OrderStatus) " +
                        "VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7)", recordItems);

                    if (result > 0)
                    {
                        ViewBag.msg = "New order is added.";
                    }
                    return View();
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Home/Register
        public ActionResult Register()
        {  
                return View();
        }

        // POST: Home/Register
        [HttpPost]
        public ActionResult Register(CustomerLogin collection)
        {

            try
            {
                // TODO: Add insert logic here
                List<object> newRecord = new List<object>();
                newRecord.Add(collection.CustomerID);
                newRecord.Add(collection.Password);
                

                object[] recordItems = newRecord.ToArray();
                int result = db.Database.ExecuteSqlCommand("INSERT INTO CUSTOMERLOGINTABLE " +
                    "(CustomerID, Password) " +
                    "VALUES (@p0, @p1)", recordItems);

                if (result > 0)
                {
                    ViewBag.msg = "Account have been created";
                }
                return View();
            }
            catch
            {
                return View();
            }


        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            // If session is valid
            if (Session["CustomerID"] != null)
            {
                var data = db.ORDERTABLE.SqlQuery("SELECT * FROM ORDERTABLE WHERE OrderID=@p0", id).SingleOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }


        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Order collection)
        {
            // If session is valid
            if (Session["CustomerID"] != null)
            {
                try
                {
                    // Create a new Order List to store details of the record to be undated
                    List<object> record = new List<object>();
                    record.Add(collection.OrderID);
                    record.Add(collection.FoodDescription);
                    record.Add(collection.DeliveryAddress);
                    record.Add(collection.DeliveryDate);
                    record.Add(collection.DeliveryTime);
                    record.Add(collection.EmailAddress);
                    record.Add(collection.ContactNumber);
                    record.Add(collection.OrderStatus);

                    object[] recordItems = record.ToArray();
                    int result = db.Database.ExecuteSqlCommand("UPDATE ORDERTABLE " +
                        "SET OrderID=@p0, FoodDescription=@p1, DeliveryAddress=@p2, DeliveryDate=@p3, DeliveryTime=@p4, EmailAddress=@p5, ContactNumber=@p6, OrderStatus=@p7 " +
                        "WHERE OrderID=" + id, recordItems);

                    if (result > 0)
                    {
                        ViewBag.msg = "Order LIST is updated.";
                    }
                    return View();
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            // If session is valid
            if (Session["CustomerID"] != null)
            {
                var data = db.ORDERTABLE.SqlQuery("SELECT * FROM ORDERTABLE WHERE OrderID=@p0", id).SingleOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Order collection)
        {
            // If session is valid
            if (Session["CustomerID"] != null)
            {
                try
                {
                    // SQL statement to delete a record
                    int result = db.Database.ExecuteSqlCommand("DELETE FROM ORDERTABLE WHERE OrderID=@p0", id);
                    // If record is deleted successfully return to Index page to show updated ORDERTABLE table
                    if (result > 0)
                    {
                        return RedirectToAction("List");
                    }
                    return View();
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
