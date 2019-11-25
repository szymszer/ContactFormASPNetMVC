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
            try
            {
                using (myDB1Entities db = new myDB1Entities())
                {
                    FormTable Fdb = new FormTable
                    {
                        ID = form.ID,
                        Date = DateTime.Now,
                        FirstName = form.FirstName,
                        LastName = form.LastName,
                        Email = form.Email,
                        AreaOfInterest = form.AreaOfInterest,
                        Phone = form.Phone,
                        Message = form.Message
                    };

                    db.FormTable.Add(Fdb);
                    
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                    mail.To.Add(new MailAddress(Fdb.Email));
                    mail.From = new MailAddress("smtp2mdszsz@gmail.com", "2MD_FORM_SzSz");
                    mail.Subject = Fdb.AreaOfInterest;
                    mail.Body = Fdb.Message + " - " + Fdb.FirstName + " " + Fdb.LastName;

                    smtpClient.Send(mail);
                    db.SaveChanges();
                    ModelState.Clear();

                    ViewBag.SuccessMessage = "Your form has been successfully submitted!";
                }
            }
            catch (Exception e)
            {
                ViewBag.SuccessMessage = "There was an error submitting your form.";
                ViewBag.Details = e.Message;
                //throw e;
            }




            return View("SubmitForm");
        }
    }
}