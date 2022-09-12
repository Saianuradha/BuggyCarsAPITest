using BuggyCarsAPITest.Models;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using Newtonsoft.Json;

namespace BuggyCarsAPITest
{
    [TestFixture]
    public class Class1
    {
        private string hostUrl = "https://k51qryqov3.execute-api.ap-southeast-2.amazonaws.com/prod";
        private string profileUrlPath = "/users/profile";
        private string tokenUrlPath = "/oauth/token";
        private string oAuthToken;
        private string ProfileOutput;

        [Test]
        public  void LoginStatusOKTest()
        {
            var client = new RestClient(hostUrl);
            var request = new RestRequest(tokenUrlPath, Method.Post);

            request.AddParameter("grant_type", "password");
            request.AddParameter("username", "Anu4");
            request.AddParameter("password", "Test@1234567");
            var response = client.Execute(request);
            ResponseToken responseToken = JsonConvert.DeserializeObject<ResponseToken>(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            oAuthToken= responseToken.AccessToken;
            
        }

        [Test]
        public void GetProfileTest()
        {
            var client = new RestClient(hostUrl);

            var request = new RestRequest(tokenUrlPath, Method.Post);

            request.AddParameter("grant_type", "password");
            request.AddParameter("username", "Anu4");
            request.AddParameter("password", "Test@1234567");
            var response = client.Execute(request);
            ResponseToken responseToken = JsonConvert.DeserializeObject<ResponseToken>(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            oAuthToken = responseToken.AccessToken;

            var request2 = new RestRequest(profileUrlPath, Method.Get);
            Console.WriteLine(oAuthToken);
            request2.AddHeader("authorization", "Bearer " + oAuthToken);
            var response2 = client.Execute(request2);
            ResponseProfile profile = JsonConvert.DeserializeObject<ResponseProfile>(response2.Content);
           
            Console.WriteLine(profile.UserName);
            Assert.AreEqual("Anu4", profile.UserName);
            Assert.AreEqual(HttpStatusCode.OK, response2.StatusCode);
           

        }

        [Test]
        public void ProfileEndPointStatusUnAuthTest()
        {
            var client = new RestClient(hostUrl);
            var request = new RestRequest(profileUrlPath, Method.Get);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("authorization", "Bearer WRONG_OAUTH");
            RestResponse response = client.Execute(request);


            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));

        }

       
    }
}
