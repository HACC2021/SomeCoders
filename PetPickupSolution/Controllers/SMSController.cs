//using Microsoft.AspNetCore.Mvc;
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
using PetPickupSolution.Models;

namespace PetPickupSolution.Controllers
{
    public class SMSController : TwilioController
    {

        //auth error here... think it has to do with a new authToken being generated... unable to send messages
        //[HttpPost]
        public void SendSMS()
        {
            //commenting out for now but before site is launched this needs to be implemented for security
            //var accountSID = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            //var authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            var accountSID = "ACb3e690d2ed4b17436d984e0225c16094";
            var authToken = "48cb22c64f90bd1474ec96ac37f95dc3";
            var testPhoneNumber = "+18084927514";
            var testPetName = "Berry";

            TwilioClient.Init(accountSID, authToken);

            var message = MessageResource.Create(
                body: testPetName + " is ready to be picked up!",
                from: new Twilio.Types.PhoneNumber("+18082013388"),
                to: new Twilio.Types.PhoneNumber(testPhoneNumber)
            );

            Console.WriteLine(message.Sid);
        }

        //[HttpPost] //not sure if we need the httppost
        public TwiMLResult RecieveSMS()
        {
            var messagingResponse = new MessagingResponse();
            messagingResponse.Message("Your message has been recieved! Your phone number has been account to the your pet and you will recieve a text message when your pet" +
                "is ready to be picked up.");

            //code to add phone number to db here

            //this is causing errors, need to add SQL commands here
            return TwiML(messagingResponse);
        }
        

    }
}
