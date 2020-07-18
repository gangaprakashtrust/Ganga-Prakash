using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GangaPrakashAPI.Model;
using Microsoft.AspNet.SignalR;

namespace GangaPrakash.UI
{
    public class ChatHub : Hub
    {
        public async Task Send(String ApplicationUserId, String Username, String Text, String DateTime)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(ApplicationUserId, Username, Text, DateTime);
        }

    }
}