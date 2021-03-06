﻿using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using CacheBuddy.Services;

namespace CacheBuddy
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                // calculate something for us to return
                int length = (activity.Text ?? string.Empty).Length;
                Activity reply;
                if (activity.Text.Equals("gru"))
                {
                    reply = activity.CreateReply("Boris");
                } else if (activity.Text.Equals("How many hours of vacation do I have left?"))
                {
                    reply = getVacationDaysRemaining(activity);
                } else if (activity.Text.Equals("launch selenium")){
                    VacationTracker vacationTracker = new VacationTracker();
                    String replyString = vacationTracker.getRemainingVacationDays();
                    reply = activity.CreateReply(replyString);
                } else if (activity.Text.Equals("current time in india"))
                {
                    ClockService clockService = new ClockService();
                    String time = clockService.getTimeInIndia();
                    reply = activity.CreateReply(time);
                }
                else if (activity.Text.Equals("current time in uk"))
                {
                    ClockService clockService = new ClockService();
                    String time = clockService.getTimeInUK();
                    reply = activity.CreateReply(time);
                }
                else
                {
                    reply = activity.CreateReply("Sorry I do not understand. Try asking in Spanish.");
                }
                // return our reply to the user
                //Activity reply = activity.CreateReply($"You sent {activity.Text} which was {length} characters");
                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity getVacationDaysRemaining(Activity activity)
        {
            return activity.CreateReply("0... Sucks for you");
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}