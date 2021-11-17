using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System;

using Twilio;
using Twilio.Rest.Api.V2010.Account;

using Twilio.Types;

using Twilio.TwiML;
using Twilio.AspNet.Mvc;

namespace PetPickupSolution.Controllers
{
    public class SMSController : Controller
    {
        public ActionResult SendSMS()
        {
            //commenting out for now but before site is launched this needs to be implemented for security
            //var accountSID = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            //var authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            var accountSID = "ACb3e690d2ed4b17436d984e0225c16094";
            var authToken = "c2094c7b12e4309df3320a72aecfc8ca";

            TwilioClient.Init(accountSID, authToken);

            var message = MessageResource.Create(
                body: "Test Message",
                from: new Twilio.Types.PhoneNumber("+18082013388"),
                to: new Twilio.Types.PhoneNumber("+18084927514")
            );

            return Content(message.Sid);
        }

        [HttpPost]
        public ActionResult TwiMLResult()
        {
            var messagingResponse = new MessagingResponse();
            messagingResponse.Message("Your message has been recieved! Your phone number has been account to the your pet and you will recieve a text message when your pet" +
                "is ready to be picked up.");

            return TwiML(messagingResponse);
        }
    }
}
