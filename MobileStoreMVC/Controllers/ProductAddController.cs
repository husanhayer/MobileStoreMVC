using MobileStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileStoreMVC.Controllers
{
    public class ProductAddController : Controller
    {
       // create the object of the entity model for databse connectivity and queries with the crud 
        public   ProductAddModel db = new ProductAddModel();


        // GET: ProductAdd
        // this method is used to get the list of the product from the database 
        public ActionResult ProductAdd()
        {
            return View(db.Products.ToList());
        }

        // GET: ProductAdd/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // this method is used to create the new page to add the product in the table of tha database using crud 
        // GET: ProductAdd/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductAdd/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Product productToCreate)
        {
            if (!ModelState.IsValid)
                return View();
            db.Products.Add(productToCreate);
            db.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("ProductAdd");
        }

        // GET: ProductAdd/Edit/5
        //this method is used to update the product from the table using crud with the product id 
        public ActionResult Edit(int id)
        {
            var ProductToEdit = (from m in db.Products where m.ID == id select m).First();
            return View(ProductToEdit);
        }

        // POST: ProductAdd/Edit/5
        [HttpPost]
        public ActionResult Edit(Product productToEdit)
        {
            var orignalRecord = (from m in db.Products where m.ID == productToEdit.ID select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            db.Entry(orignalRecord).CurrentValues.SetValues(productToEdit);

            db.SaveChanges();
            return RedirectToAction("ProductAdd");



        }
        // delete the record form the table for ever using the crud concept 
        // GET: ProductAdd/Delete/5
        public ActionResult Delete(Product productToDelete)
        {

            var d = db.Products.Where(x => x.ID == productToDelete.ID).FirstOrDefault();
            db.Products.Remove(d);
            db.SaveChanges();
            return RedirectToAction("ProductAdd");
        }

        // POST: ProductAdd/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
                return View();
            
        }
    }
}
