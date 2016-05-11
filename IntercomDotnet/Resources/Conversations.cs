using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntercomDotNet.Resources
{
    public class Conversations : Resource
    {
        public Conversations(Client client)
            : base(client, "conversations")
        {
        }

        /// <summary>
        /// Fetch a list of all conversations 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="admin_id"></param>
        /// <param name="open"></param>
        /// <returns></returns>
        public dynamic GetAllUserConversations()
        {
            return Client.Execute(BaseUrl, Method.GET, request => { });
        }

        /// <summary>
        /// Fetch user conversation with admin
        /// </summary>
        /// <param name="type"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public dynamic Get(string user_id)
        {
            return Client.Execute(BaseUrl, Method.GET, request =>
            {
                request.AddParameter("type", "user");
                //request.AddParameter("unread", true);

                if (!string.IsNullOrEmpty(user_id))
                    request.AddParameter("user_id", user_id);
            });
        }

        /// <summary>
        /// Fetch Single conversation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic GetSingleConversation(string id)
        {
            return Client.Execute(BaseUrlWithId, Method.GET, request =>
            {
                if (!string.IsNullOrEmpty(id))
                    request.AddUrlSegment("id", id);
            });
        }

        /// <summary>
        /// Replying to conversation from user to admin
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public dynamic ReplyingConversationFromUsertoAdmin(string user_id,string conversationID, string body)
        {
            return Client.Execute(BaseUrlWithId + "/reply", Method.POST, request =>
            {
                request.RequestFormat = DataFormat.Json;

                request.AddParameter("type", "user");
                request.AddParameter("message_type", "comment");

                if (!string.IsNullOrEmpty(conversationID))
                    request.AddUrlSegment("id", conversationID);

                if (!string.IsNullOrEmpty(body))
                    request.AddParameter("body", body);

                if (!string.IsNullOrEmpty(user_id))
                    request.AddParameter("user_id", user_id);
            });

        }

        /// <summary>
        /// Reply to last conversation from user to admin
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public dynamic ReplytoLastConversationFromUsertoAdmin(string user_id,string body)
        {
            return Client.Execute(BaseUrl + "/last/reply", Method.POST, request =>
            {
                request.RequestFormat = DataFormat.Json;

                request.AddParameter("type", "user");
                request.AddParameter("message_type", "comment");

                if (!string.IsNullOrEmpty(body))
                    request.AddParameter("body", body);

                if (!string.IsNullOrEmpty(user_id))
                    request.AddParameter("user_id", user_id);

            });
        }

        /// <summary>
        /// Reply to last conversation from admin to user
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public dynamic ReplytoLastConversationFromAdmintoUser(string admin_id, string user_id, string body)
        {
            return Client.Execute(BaseUrl + "/last/reply", Method.POST, request =>
            {
                request.RequestFormat = DataFormat.Json;

                request.AddParameter("type", "admin");
                request.AddParameter("message_type", "comment");

                if (!string.IsNullOrEmpty(body))
                    request.AddParameter("body", body);

                if (!string.IsNullOrEmpty(admin_id))
                    request.AddParameter("admin_id", admin_id);

                if (!string.IsNullOrEmpty(user_id))
                    request.AddParameter("user_id", user_id);
 
            });
        }

        /// <summary>
        /// Mark conversation as read 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic MarkConversations(string id)
        {
            return Client.Execute(BaseUrlWithId, Method.PUT, request =>
            {
                request.RequestFormat = DataFormat.Json;

                if (!string.IsNullOrEmpty(id))
                    request.AddUrlSegment("id", id);

                request.AddBody(new
                {
                    read = true
                });
            });
        }

        /// <summary>
        /// Close a conversation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic CloseConversations(string conversationID, string admin_id)
        {
            return Client.Execute(BaseUrlWithId + "/reply", Method.POST, request =>
            {
                request.RequestFormat = DataFormat.Json;

                if (!string.IsNullOrEmpty(conversationID))
                    request.AddUrlSegment("id", conversationID);

                if (!string.IsNullOrEmpty(admin_id))
                    request.AddParameter("admin_id", admin_id);

                request.AddParameter("type", "admin");

                request.AddParameter("message_type", "close");

            });
        }


    }
}
