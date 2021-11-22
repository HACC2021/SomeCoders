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
//using Twilio.AspNet.Mvc;
using Twilio.AspNet.Core;
using PetPickupSolution.Models;
using Microsoft.Data.SqlClient;

namespace PetPickupSolution.Controllers
{
    public class SMSController : TwilioController
    {

        //connect to database
        string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

        //[HttpPost]
        public void SendSMS()
        {
            //implemented for security
            var accountSID = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            var authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            var testPhoneNumber = Environment.GetEnvironmentVariable("TEST_PHONE_NUMBER");
            var testFromPhoneNumber = Environment.GetEnvironmentVariable("TEST_FROM_PHONE_NUMBER");
            var testPetName = Environment.GetEnvironmentVariable("TEST_PET_NAME");

            TwilioClient.Init(accountSID, authToken);

            var message = MessageResource.Create(
                body: testPetName + " is ready to be picked up!",
                from: new Twilio.Types.PhoneNumber(testFromPhoneNumber),
                to: new Twilio.Types.PhoneNumber(testPhoneNumber)
            );

            Console.WriteLine(message.Sid);
        }

        //[HttpPost]
        public void ReceiveSMS(string From, string Body, string connectionString)
        {
            var twiml = new MessagingResponse();
            //possibly add input validation
            twiml.Message(From);

            Console.WriteLine(From);
            //code to add phone number to db here

            //string queryString = "UPDATE PetPickupModel SET OwnerPhoneNumber = From WHERE PetMicroChipID = Body;";
            
            //using (SqlConnection connection = new SqlConnection(connectionString)
            //{
            //    SqlCommand command = new SqlCommand(queryString, connection);
            //}

            //return TwiML(twiml);
        } 
    }
}
