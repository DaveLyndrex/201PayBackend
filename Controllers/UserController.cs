/*[10/11/2021] CN E.Patot*/
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using BackEnd.Services;
using Newtonsoft.Json;
using System.Net.Http;

namespace BackEnd.Controllers
{
    public class UserController : ApiController
    {
        ResponseModel response = new ResponseModel();

        [HttpPost, Route("api/user/login")]
        public async Task<IHttpActionResult> UserLogin([FromBody] EncryptedDataModel edm)
        {
            UserModel um = (UserModel)Encryptor.getByModel(typeof(UserModel), edm);
            var client = new HttpClient()
            {
                BaseAddress = new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority))
            };

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", um.username),
                new KeyValuePair<string, string>("email", um.email),
                new KeyValuePair<string, string>("password", um.password),
                new KeyValuePair<string, string> ("isGmail", um.isGmail.ToString())
            }); 

            var result = await client.PostAsync("/api/token", content);
            string resultContent = await result.Content.ReadAsStringAsync();
            resultContent = resultContent.Replace(".issued", "issued").Replace(".expires", "expires");

            return Ok(await Task.Run(() => resultContent));
        }

        [HttpPost, Route("api/user/loginWithGoogle")]
        public async Task<IHttpActionResult> UserLoginWithGoogle([FromBody] EncryptedDataModel edm)
        {
            UserModel um = (UserModel)Encryptor.getByModel(typeof(UserModel), edm);

            var client = new HttpClient()
            {
                BaseAddress = new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority))
            };

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", um.username),
                new KeyValuePair<string, string>("email", um.email),
                new KeyValuePair<string, string>("password", um.password),
                new KeyValuePair<string, string> ("isGmail", um.isGmail.ToString())
            });

            var result = await client.PostAsync("/api/token", content);
            string resultContent = await result.Content.ReadAsStringAsync();
            resultContent = resultContent.Replace(".issued", "issued").Replace(".expires", "expires");

            return Ok(await Task.Run(() => resultContent));
        }

        [HttpGet, Route("api/user/profile/{empId}"), Authorize]
        public async Task<IHttpActionResult> UserLoginWithGoogle([FromUri] int empId)
        {
            UserService user = new UserService();
            response = user.getUserProfileById(empId);

            return Ok(await Task.Run(() => response));
        }

        [HttpGet, Route("api/getDatabaseParameters"), Authorize]
        public async Task<IHttpActionResult> getDatabaseParameters()
        {
            UserService user = new UserService();

            response = user.getDatabaseParameters();

            return Ok(await Task.Run(() => JsonConvert.SerializeObject(response)));
        }
    }
}
