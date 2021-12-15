using Microsoft.Owin;
using Owin;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using BackEnd.Provider;
using System.Web.Http;
using Microsoft.Owin.Cors;

namespace BackEnd
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions options { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCors(CorsOptions.AllowAll);

            //Defining OAuthAuthorizationServer Options
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true, //do not allow in development environment
                TokenEndpointPath = new PathString("/api/token"), //this is path where user will get token,after getting validated
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1), //token expiration 
                Provider = new MyAuthorizationProvider(),
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
