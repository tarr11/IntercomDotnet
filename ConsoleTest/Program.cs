using IntercomDotNet;
using System;

namespace ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                string apikey = "";
                string appid = "";
                var client = IntercomClient.GetClient(appid, apikey);

                //var user = client.Users.Get();
               // var newuser = client.Users.Post(new { email = "test@test.com" });
                //client.Users.Delete("put id here");
                //client.Users.DeleteWithUserId("put user_id here");

                //client.Events.Post("test_event", DateTime.Now, "userid", new { });

                //---- Conversations examples----
                //create a new admin initiated message
                //client.Messages.Post("email", "Hello", "This is just a test message", "personal", "put admin id here", "put user_id here");

                //User or Contact Initiated Conversation
                //client.Messages.Post("userid", "Message Body..");

                //Fetch a list of all conversations 
                //client.Conversations.GetAllUserConversations();

                //Get a Single Conversation
                //client.Conversations.GetSingleConversation("Conversation ID");
                
                //Replying from user to admin with a conversationID
                //client.Conversations.ReplyingConversation("UserID", "conversationID", "Message body");

                //Replying from user admin to a last conversation without ID
                //client.Conversations.ReplytoLastConversation("UserID", "Message body");

                //Replying from admin to user last conversation
                //client.Conversations.ReplytoLastConversationFromAdmintoUser("admin_id", "user_id", "Reply from admin to user");

                //Mark conversation as read
                //client.Conversations.MarkConversations("conversationID");

                //Close a conversation
                //client.Conversations.CloseConversations("conversationID", "adminID");

                // Admins examples
                //Get list of admins
                client.Admin.GetAllAdmins();

                //View Admin
                client.Admin.ViewAdmin("484781");

                //Counts examples
                //Get App Count
                client.Count.GetAppCount();

                //Get Conversation Count
                client.Count.GetConversationAppCount();

                //Get Conversation Admin Count
                client.Count.GetConversationAdminCount();

                //Get User Tag Count
                client.Count.GetUserTagCount();

                //Get User Segment Count
                client.Count.GetUserSegmentCount();

                //Get Company Segment Count
                client.Count.GetCompanySegmentCount();

                //Get Company Tag Count
                client.Count.GetCompanyTagCount();

                //Get Company User Count
                client.Count.GetCompanyUserCount();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
