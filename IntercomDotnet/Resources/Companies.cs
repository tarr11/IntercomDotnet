using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntercomDotNet.Resources
{
    public class Companies : Resource
    {
        public Companies(Client client) : base(client, "companies")
        {
        }

        public dynamic Post(object hash)
        {
            return Client.Execute(BaseUrl, Method.POST, request =>
                {
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(hash);
                });
        }
        
        public dynamic Get(string name, string companyId) 
        {
            return Client.Execute(BaseUrl, Method.GET, request =>
            {
                if (name != null)
                    request.AddParameter("name", name);

                if (companyId != null)
                    request.AddParameter("company_id", companyId);
            });
        }

        public dynamic GetCompanyList(string tagId = null, string segmentId = null)
        {
            return Client.Execute(BaseUrl, Method.GET, request =>
            {
                if (tagId != null)
                    request.AddParameter("tag_id", tagId);

                if (segmentId != null)
                    request.AddParameter("segment_id", segmentId);
            });
        }

        public dynamic GetCompanyList(int page = 1, int perPage = 50, string order = null)
        {
            return Client.Execute(BaseUrl, Method.GET, request =>
            {
               request.AddParameter("page", page);
               request.AddParameter("per_page", perPage);

                if (order != null)
                    request.AddParameter("order", order);
            });
        }
    }
}
