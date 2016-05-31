using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntercomDotNet.Resources
{
    public class Admins : Resource
    {
        public Admins(Client client)
            : base(client, "admins")
        {
        }

        public dynamic GetAllAdmins()
        {
            return Client.Execute(BaseUrl, Method.GET, request => { });
        }

        public dynamic ViewAdmin(String id)
        {
            return Client.Execute(BaseUrl, Method.GET, request =>
            {
                request.AddParameter("id", id);
            });
        }
    }
}
