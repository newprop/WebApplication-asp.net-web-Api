using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(WebApplication1.Startup))]

namespace WebApplication1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions()
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters=new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = ConfigurationManager.AppSettings["JwtIssuer"],

                    ValidAudience = ConfigurationManager.AppSettings["JwtAudience"],
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["JwtKey"]))

                }







            }) ;
        } 
    }
}
