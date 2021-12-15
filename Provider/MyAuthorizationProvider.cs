/*[10/11/2021] CN E.Patot*/
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin;
using BackEnd.Services;
using BackEnd.Models;

namespace BackEnd.Provider
{
    public class MyAuthorizationProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();   // we just validated our client app
        }

        // function called when we want to supply Addtional Response Parameters
        public override Task TokenEndpoint(OAuthTokenEndpointContext context) 
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var clientIp = context.Request.LocalIpAddress;

            UserService user = new UserService();
            LogsService logs = new LogsService();

            ResponseModel response = new ResponseModel();

            return Task.Factory.StartNew(async () =>
            {
                IFormCollection parameters = await context.Request.ReadFormAsync();
                string username = parameters.Get("username");
                string password = parameters.Get("password");
                string email = parameters.Get("email");
                string isGmail = parameters.Get("isGmail");

                LoginResponse loginResponse = new LoginResponse();

                if (isGmail == "0" )
                {
                    loginResponse = user.CheckLocalUserCredentials(username, password, email);
                } 
                else
                {
                    loginResponse = user.CheckUserGmailCredentials(email);
                }

                if (loginResponse.role != "NONE")
                {
                    var claims = new List<Claim>()
                    {
                        new Claim("Username", username),
                        new Claim(ClaimTypes.Role, loginResponse.role),
                    };

                    ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);

                    var properties = CreateProperties(loginResponse);
                    var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                    var success = context.Validated(ticket);
                    logs.insertUserLoggedInLogs(clientIp, username, email, success.ToString());          
                }
                else
                {
                    
                    response = logs.insertUserLoggedInLogs(clientIp, username, email, "invalid_grant", loginResponse.message);
                    if (response.error == true)
                    {
                        context.SetError("invalid_grant", response.message);
                    } 
                    else
                    {
                        context.SetError("invalid_grant", loginResponse.message);
                    }
                    return;
                }
            });
        }

        public static AuthenticationProperties CreateProperties(LoginResponse response)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "role", response.role },
                { "empId", response.empId },
            };
            return new AuthenticationProperties(data);
        }
    }
}