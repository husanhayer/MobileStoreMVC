using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using MobileStoreMVC.Models;

namespace MobileStoreMVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        //other controller for the contact page that is used to send the record to the database so thus it can store the record for ever
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
//other method of the connection string that is used to set the connection between front end and backend 
        void connectionString()
        {
            con.ConnectionString = "Data Source=LAPTOP-NI9FNBTG\\SQLEXPRESS02;Initial Catalog=MobileStore;Integrated Security=True";

        }
        // this is used for sending the msg to the owner as a feed back option with the message 

        [HttpPost]
        public ActionResult sendMsg(ContactData log)
        {
            connectionString();
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "insert into Contact(MName,MEmail,MPhone,MMsg) values('"+log.SName+"','"+log.SEmail+"','"+log.SPhone+"','"+log.SMsg+"')";
            cmd.ExecuteNonQuery();
            con.Close();
           // affter sending the message record will move to the feed back form 
            return View("FeedBack");
            
            
        }


    }
}