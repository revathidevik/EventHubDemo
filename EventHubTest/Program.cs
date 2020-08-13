using EventHubTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHubTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string EventHubConnectionString = ConfigurationManager.ConnectionStrings["EventHubConnectionString"].ConnectionString;
            string BlobStorageConnection = ConfigurationManager.ConnectionStrings["BlobStorageConnection"].ConnectionString;
            BlobStorage.SavePdf(BlobStorageConnection);
            AttachmentMetaData eventHubMessage = new AttachmentMetaData()
            {
               
            };
            EventHubsHelper.PushMessageToEventHubsAsync(eventHubMessage, EventHubConnectionString);

        }
    }
}
