using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Caching;
using ServiceStack.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ServiceStackDemo
{
    public class Global : System.Web.HttpApplication
    {

        public class ProteinTrackerAppHost : AppHostBase
        {
            public ProteinTrackerAppHost() : base("Protein Tracker", typeof(EntryService).Assembly) {}

            public override void Configure(Funq.Container container)
            {
                // Configure Application
                Plugins.Add(new AuthFeature(() => 
                new AuthUserSession(), new IAuthProvider[] {
                    new BasicAuthProvider() }));

                // Enable user registration
                Plugins.Add(new RegistrationFeature());

                // Cache Client
                container.Register<ICacheClient>(new MemoryCacheClient());

                // InMemory Auth Repository
                var userRepository = new InMemoryAuthRepository();
                container.Register<IUserAuthRepository>(userRepository);

                // Register Sample User
                string hash;
                string salt;

                new SaltedHash().GetHashAndSaltString("passwort", out hash, out salt);
                userRepository.CreateUserAuth(new UserAuth
                {
                    Id = 1,
                    DisplayName = "Marcel",
                    Email = "jm@example.com",
                    UserName = "MJurtz",
                    FirstName = "Marcel",
                    LastName = "User",
                    Roles = new List<string> { RoleNames.Admin },
                    //Permissions = new List<string> { "GetStatus"},
                    PasswordHash = hash,
                    Salt = salt
                }, "password");
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            new ProteinTrackerAppHost().Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}