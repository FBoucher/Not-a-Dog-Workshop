using System.Collections.Generic;
using Microsoft.Azure.Storage.Blob;

namespace NotADog.Services
{
    public interface IBlobStorageManager
    {
        IEnumerable<IListBlobItem> GetFiles(string containerName);
    }
}