using ServiceStack;
using ServiceStackDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonServiceClient client = new JsonServiceClient("http://localhost:60505") { UserName = "MJurtz", Password = "password"};
            client.Send<AssignRolesResponse>(new AssignRoles
            { 
                UserName = "MJurtz",
                Roles = new ArrayOfString("User"),
                Permissions = new ArrayOfString("GetStatus")
            });
            int amount = -1;
            while(amount != 0)
            {
                // Get user input
                Console.WriteLine("Enter amount, 0 to exit");
                amount = int.Parse(Console.ReadLine());

                // General Purpose, verb is applied by server
                var response = client.Send(new Entry { Amount = amount, Time = DateTime.Now });
                Console.WriteLine(response.Message);

                
            }

            StatusResponse statusResponse = null;
            try
            {
                statusResponse = client.Post(new StatusQuery { Date = DateTime.Now });
                Console.WriteLine("{0} / {1}", statusResponse.Total, statusResponse.Goal);
                Console.WriteLine("Last IP: " + statusResponse.Message);
            }
            catch(WebServiceException exception)
            {
                Console.WriteLine(exception.StatusDescription);
                Console.ReadLine();
            }
            
            

            Console.ReadLine();
        }
    }
}
