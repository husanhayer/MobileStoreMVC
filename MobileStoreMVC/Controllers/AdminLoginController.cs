using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MobileStoreMVC.Models;

namespace MobileStoreMVC.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin

            //global Object of database class to  execute the connection and query regarding the mvc Controller  this is used for login controll to check the user name is correct or not if it is correct then then the nxt form will be open other wise it will give an error message 
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        //connection string method is used to store the connection srtring so thus it can use every where  
        void connectionString()
        {
            con.ConnectionString = "Data Source=LAPTOP-NI9FNBTG\\SQLEXPRESS02;Initial Catalog=MobileStore;Integrated Security=True";

        }
        
        [HttpPost]
        public ActionResult Verify(AdminLogin log)
        {
            //working of the database connectivty so thus connection can be work and verify the record after matching 

            connectionString();
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "select * from AdminLogin where MUserName='" + log.MUserName + "' and MPassword='" + log.MPassword + "'";
            
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                con.Close();
                // if the user namre and passworrd is true then the next page adminzone will be open other wise the it will open the invalid page will be open 
                return View("AdminZone");
            }
            else
            {
                // it will transfer to the invalid page 
                con.Close();
                return View("Invalid");
            }
        }

    }
}