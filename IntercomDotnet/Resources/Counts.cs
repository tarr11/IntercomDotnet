using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntercomDotNet.Resources
{
    public class Counts : Resource
    {
        public Counts(Client client)
            : base(client, "counts")
        {
        }

        public dynamic GetAppCount()
        {
            return Client.Execute(BaseUrl, Method.GET, request => { });
        }

        public dynamic GetConversationAppCount()
        {
            return Client.Execute(BaseUrl, Method.GET, request =>
            {
                request.AddParameter("type", "conversation");
            });
        }

        public dynamic GetConversationAdminCount()
        {
            return Client.Execute(BaseUrl, Method.GET, request =>
            {
                request.AddParameter("type", "conversation");
                request.AddParameter("count", "admin");
            });
        }

        public dynamic GetUserTagCount()
        {
            return Client.Execute(BaseUrl, Method.GET, request =>
            {
                request.AddParameter("type", "user");
                request.AddParameter("count", "tag");
            });
        }

        public dynamic GetUserSegmentCount()
        {
            return Client.Execute(BaseUrl, Method.GET, request =>
            {
                request.AddParameter("type", "user");
                request.AddParameter("count", "segment");
            });
        }

        public dynamic GetCompanySegmentCount()
        {
            return Client.Execute(BaseUrl, Method.GET, request =>
            {
                request.AddParameter("type", "company");
                request.AddParameter("count", "segment");
            });
        }

        public dynamic GetCompanyTagCount()
        {
            return Client.Execute(BaseUrl, Method.GET, request =>
            {
                request.AddParameter("type", "company");
                request.AddParameter("count", "tag");
            });
        }

        public dynamic GetCompanyUserCount()
        {
            return Client.Execute(BaseUrl, Method.GET, request =>
            {
                request.AddParameter("type", "company");
                request.AddParameter("count", "user");
            });
        }
    }
}
