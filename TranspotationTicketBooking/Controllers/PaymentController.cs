using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
//using TranspotationTicketBooking.Models;

public class StripeOptions
{
    public string option { get; set; }

}
public class Payment
{
    public int TId { get; set; }
    public string Road { get; set; }
    public int Price { get; set; }
    public string CusEmail { get; set; }
    public string Description { get; set; }

}
public class MessageInfo
{
    public int TId { get; set; }
    public string Road { get; set; }
    public int Price { get; set; }
    public int Seats { get; set; }
    public string Date { get; set; }
    public int SId { get; set; }
    public string BusNo { get; set; }
    public string Telephone { get; set; }

}

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TranspotationTicketBooking.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        // GET: api/<PaymentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("smsapi")]
        public async Task<ActionResult<string>> PostSmsAsync(MessageInfo messageInfo)
        {
            string url = "https://app.smsapi.lk/sms/api?action=send-sms&api_key=aGFyaXRoOkhhcml0aDEyMyE=&to="+messageInfo.Telephone+"&from=Ticketz&sms=Your+Ticket ("+messageInfo.TId+ ")%0a%0a" + messageInfo.Road+"%0a"+messageInfo.Date+"%0aSeats-"+messageInfo.Seats+"%0aPrice- LKR"+messageInfo.Price+"%0aSession ID:"+messageInfo.SId+"%0aBus No:"+messageInfo.BusNo+"%0a*****************%0aTICKETZ"; // sample url
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }

        }

            // POST api/<PaymentController>
            [HttpPost]
        public ActionResult Post(Payment payment)
        {
            var domain = "http://localhost:3000/ticket";
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = payment.Price,
                            Currency = "lkr",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = payment.Road,
                                Description = payment.Description,
                                Images = new List<string>{ "https://ticketz-payment.appmith.com/logo.png", },
                            },
                        },
                        Quantity = 1,
                    },
                },
                ClientReferenceId = payment.TId.ToString(),
                CustomerEmail = payment.CusEmail,
                Mode = "payment",
                SuccessUrl = domain + "?success=true",
                CancelUrl = domain + "?success=false",
            };
            var service = new SessionService();
            Session session = service.Create(options);
            //return Json(new { id = session.Id });
             return Ok(new { id = session.Id, payment_id=session.PaymentIntentId });
           // return CreatedAtAction("GetSession", new { id = session.Id });
        }

       
    }
}
