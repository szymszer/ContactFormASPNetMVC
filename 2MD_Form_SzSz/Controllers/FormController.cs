using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;

namespace _2MD_Form_SzSz.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        [HttpGet]
        public ActionResult AddForm(int id = 0)
        {
            Form form = new Form();
            return View(form);
        }

        [HttpPost]
        public ActionResult AddForm(Form form)
        {
            using (myDB1Entities db = new myDB1Entities())
            {
                var Fdb = new FormTable();
                Fdb.ID = form.ID;
                Fdb.Date = DateTime.Now;
                Fdb.FirstName = form.FirstName;
                Fdb.LastName = form.LastName;
                Fdb.Email = form.Email;
                Fdb.AreaOfInterest = form.AreaOfInterest;
                Fdb.Phone = form.Phone;
                Fdb.Message = form.Message;

                db.FormTable.Add(Fdb);
                try
                {
                    db.SaveChanges();

                    // TODO: move smtp settings to web config
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.Credentials = new System.Net.NetworkCredential("smtp2mdszsz@gmail.com", "BardzoTajne!1");
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = true;
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

                    mail.To.Add(new MailAddress(Fdb.Email));     
                    mail.From = new MailAddress("smtp2mdszsz@gmail.com", "2MD_FORM_SzSz");
                    mail.Subject = Fdb.AreaOfInterest;
                    mail.Body = Fdb.Message;

                    smtpClient.Send(mail);


                    ViewBag.SuccessMessage = "Your form has been successfully submitted!";
                }
                catch (Exception e)
                {
                    ViewBag.SuccessMessage = "There was an error submitting your form.";
                    throw e;
                }

                ModelState.Clear();
            }


            return View("SubmitForm");
        }
    }
}