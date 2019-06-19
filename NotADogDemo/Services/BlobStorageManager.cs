using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Options;

namespace NotADog.Services
{
    public class BlobStorageManager : IBlobStorageManager
    {
        private readonly CloudStorageAccount _storageAccount;

        public BlobStorageManager(IOptions<StorageAccountOptions> options)
        {
            if (options == null) { throw new ArgumentNullException(nameof(options)); }
            _storageAccount = CreateCloudStorageAccount(options.Value);
        }

        private CloudStorageAccount CreateCloudStorageAccount(StorageAccountOptions options)
        {
            if (!CloudStorageAccount.TryParse(options.ConnectionString, out CloudStorageAccount storageAccount))
            {
                throw new Exception("Invalid storage account connecting string. Please verify the connection string and try again");
            }
            return storageAccount;
        }

        public IEnumerable<IListBlobItem> GetFiles(string containerName)
        {
            var cloudBlobClient = _storageAccount.CreateCloudBlobClient();
            var container = cloudBlobClient.GetContainerReference(containerName);
            var blobs = container.ListBlobs();
            return blobs;
        }

        public bool UploadFile(string fileUrl, string containerName)
        {
            var cloudBlobClient = _storageAccount.CreateCloudBlobClient();
            var container = cloudBlobClient.GetContainerReference(containerName);
            var fileName = fileUrl.Split('/').Last();
            var blobs = container.GetBlockBlobReference(fileName);

            var file = DownloadFile(fileUrl).Result;
            if(file != null)
            {
                blobs.UploadFromByteArray(file, 0, file.Length);
                return true;
            }
            return false;
        }

        private static async Task<byte[]> DownloadFile(string url)
        {
            using (var client = new HttpClient())
            {

                using (var result = await client.GetAsync(url))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        return await result.Content.ReadAsByteArrayAsync();
                    }

                }
            }
            return null;
        }
    }
}