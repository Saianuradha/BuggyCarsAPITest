using BuggyCarsAPITest.Models;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;

namespace BuggyCarsAPITest
{
    [TestFixture]
    public class Class1
    {
         private string hostUrl = "https://k51qryqov3.execute-api.ap-southeast-2.amazonaws.com/";
         private string profileUrlPath = "prod/users/profile";
        private string tokenUrlPath = "prod/oauth/token";


        [Test]
        public async void LoginStatusOKTest()
        {
            var client = new RestClient(hostUrl);
            var request = new RestRequest(tokenUrlPath, Method.Post);

            request.AddParameter("grant_type", "password");
            request.AddParameter("username", "Anu4");
            request.AddParameter("password", "Test@1234567");

            RestResponse response = await client.ExecuteAsync<RestResponse>(request);

            ResponseToken tokenResponse = new JsonDeserializer().Deserialize<ResponseToken>(response);


            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
        public void ProfileEndPointStatusOKTest()
        {
            var client = new RestClient(hostUrl);
            var request = new RestRequest(profileUrlPath, Method.Get);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("authorization", "Bearer eyJraWQiOiJ0UkRnSmpNekhta2tIanVvT2g3Rm5RYkRBYUdHRjQxQ2VPbEVEaWI3MkQ4PSIsImFsZyI6IlJTMjU2In0.eyJzdWIiOiJmN2M3OTA0MS00NzQ3LTQ4ODYtOWM0ZS1iOGMyZTAxN2I1NTUiLCJpc3MiOiJodHRwczpcL1wvY29nbml0by1pZHAuYXAtc291dGhlYXN0LTIuYW1hem9uYXdzLmNvbVwvYXAtc291dGhlYXN0LTJfT3A3S0d4ME1jIiwiY2xpZW50X2lkIjoiNTduZGNrZzNoZ2Y5OGZ1NHN1cXEzdjJpNGIiLCJvcmlnaW5fanRpIjoiZjhlNTJhZmUtZjhmNC00MmQ2LWFhMDctZWJlNDY3MDk0YzFhIiwiZXZlbnRfaWQiOiJmOTYzNTU1Mi0zMmUxLTQ4ZjYtODVlMC0xZjdhZGM0ZjVmNGQiLCJ0b2tlbl91c2UiOiJhY2Nlc3MiLCJzY29wZSI6ImF3cy5jb2duaXRvLnNpZ25pbi51c2VyLmFkbWluIiwiYXV0aF90aW1lIjoxNjYyODkxODMzLCJleHAiOjE2NjI4OTU0MzMsImlhdCI6MTY2Mjg5MTgzMywianRpIjoiNDlkMjU0MTAtZTA4My00YWVmLWI2NWUtMjE5YjdmNDc2OTU5IiwidXNlcm5hbWUiOiJBbnU0In0.keKJfr3tdYKuq1QuVB85stSTMd0aLArjrcBXAXyPiM6jLfGJ8im73Rzx_rhRmqJ47uWjZfSASYfevYCZ6rN05y0ajKZh4d73nKbkPIPm_km7rjCeWqvIdrskVuNOJFVTGNEJO65Sn39_cz21efLOJCjdV0Nuzm0tfORXN9buRf-gQM-1a13CFuOS1wOBMxQq8e3dld-Zw9O4nIvutXnxau-wjTni2TVVND9IyEcSNoiTabOTeFziZsPTZWVzgRSlOme4XK5hC1q-aJFnWsSeN3I-lcOjgGED5L5asZqOqrCZbmRiDq16b_YcT0hKVAlkDO3rSsAn60wGFk30ofqV6A");

            RestResponse response = client.Execute(request);
          

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
        public void ProfileEndPointStatusUnAuthTest()
        {
            var client = new RestClient(hostUrl);
            var request = new RestRequest(profileUrlPath, Method.Get);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("authorization", "Bearer yJraWQiOiJ0UkRnSmpNekhta2tIanVvT2g3Rm5RYkRBYUdHRjQxQ2VPbEVEaWI3MkQ4PSIsImFsZyI6IlJTMjU2In0.eyJzdWIiOiJmN2M3OTA0MS00NzQ3LTQ4ODYtOWM0ZS1iOGMyZTAxN2I1NTUiLCJpc3MiOiJodHRwczpcL1wvY29nbml0by1pZHAuYXAtc291dGhlYXN0LTIuYW1hem9uYXdzLmNvbVwvYXAtc291dGhlYXN0LTJfT3A3S0d4ME1jIiwiY2xpZW50X2lkIjoiNTduZGNrZzNoZ2Y5OGZ1NHN1cXEzdjJpNGIiLCJvcmlnaW5fanRpIjoiZjhlNTJhZmUtZjhmNC00MmQ2LWFhMDctZWJlNDY3MDk0YzFhIiwiZXZlbnRfaWQiOiJmOTYzNTU1Mi0zMmUxLTQ4ZjYtODVlMC0xZjdhZGM0ZjVmNGQiLCJ0b2tlbl91c2UiOiJhY2Nlc3MiLCJzY29wZSI6ImF3cy5jb2duaXRvLnNpZ25pbi51c2VyLmFkbWluIiwiYXV0aF90aW1lIjoxNjYyODkxODMzLCJleHAiOjE2NjI4OTU0MzMsImlhdCI6MTY2Mjg5MTgzMywianRpIjoiNDlkMjU0MTAtZTA4My00YWVmLWI2NWUtMjE5YjdmNDc2OTU5IiwidXNlcm5hbWUiOiJBbnU0In0.keKJfr3tdYKuq1QuVB85stSTMd0aLArjrcBXAXyPiM6jLfGJ8im73Rzx_rhRmqJ47uWjZfSASYfevYCZ6rN05y0ajKZh4d73nKbkPIPm_km7rjCeWqvIdrskVuNOJFVTGNEJO65Sn39_cz21efLOJCjdV0Nuzm0tfORXN9buRf-gQM-1a13CFuOS1wOBMxQq8e3dld-Zw9O4nIvutXnxau-wjTni2TVVND9IyEcSNoiTabOTeFziZsPTZWVzgRSlOme4XK5hC1q-aJFnWsSeN3I-lcOjgGED5L5asZqOqrCZbmRiDq16b_YcT0hKVAlkDO3rSsAn60wGFk30ofqV6A");

            RestResponse response = client.Execute(request);


            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));

        }

       
    }
}
