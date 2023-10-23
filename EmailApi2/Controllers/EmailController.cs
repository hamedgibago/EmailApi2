using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using NHibernate.Id;
using EmailApi2.Models;
using System.Linq;

namespace EmailApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        // GET api/email
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Person>> Get()
        {
            using (var session = NHibernateHelpper.GetSession())
            {
                var persons = session.CreateCriteria<Person>().List<Person>();
                return persons.ToList();
            }
        }

        [HttpPost]
        [Authorize]
        //[ActionName("Send")]
        public void Post([FromBody] List<string> emails)
        {
            using (var session = NHibernateHelpper.GetSession())
            {
                foreach (var email in emails)
                {                    
                    sendWithParameters(email);
                }                
            }
        }

        private void sendWithParameters(string email)
        {
            var smtpClient = new SmtpClient("smtp.yahoo.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("h@yahoo.com", "123456"),
                EnableSsl = true,
            };

            smtpClient.Send("reza@yahoo.com", email, "subject", "body");
        }
    }
}
