using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventHubTest
{
    public class BlobStorage
    {

        public static void SavePdf(string blobConnection)
        {
            //upload file blob azure storage

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse((blobConnection));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("BlobStorageContainername");
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("JNCASR APPLICATION FORM");
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(currentDirectory, "Documents", "JNCASR APPLICATION FORM.pdf");
            using (var fileStream = System.IO.File.OpenRead(filePath))
            {
                blockBlob.UploadFromStream(fileStream);
            }
        }
    }
    
}
