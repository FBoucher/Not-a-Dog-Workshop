using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Extensions.Logging;

namespace DogDemo.Function
{
    public static class DogDetector
    {
        private static readonly List<VisualFeatureTypes> Features = new List<VisualFeatureTypes>
        {
            VisualFeatureTypes.Categories, VisualFeatureTypes.Description,
            VisualFeatureTypes.Faces, VisualFeatureTypes.ImageType,
            VisualFeatureTypes.Tags
        };

        // We must provide SAS token in order to have the API read the image located at the provided URL since our container is private
        private static SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy
        {
            SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMinutes(10),
            Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.List
        };

        [FunctionName("DogDetector")]
        public static async Task Run([BlobTrigger("images/{name}", Connection = "AzureWebJobsStorage")]CloudBlockBlob myBlob, string name, ILogger log)
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();
            log.LogInformation($"Looking image {myBlob.Uri.ToString()}");
            var visionAPI =  new ComputerVisionClient(new ApiKeyServiceClientCredentials(config["ComputerVision:ApiKey"])) { Endpoint = config["ComputerVision:Endpoint"] };
            var path = $"{myBlob.Uri.ToString()}{myBlob.GetSharedAccessSignature(sasConstraints)}";

            var results = await visionAPI.AnalyzeImageAsync(path, Features);
            if(IsDog(results))
            {
                log.LogInformation($"It's a Dog");
                return;
            }
            log.LogInformation($"Not a Dog");
            await myBlob.DeleteIfExistsAsync();
        }

        private static bool IsDog(ImageAnalysis image)
        {
            return image.Categories.Any(x => x.Name == "animal_dog") || image.Tags.Any(x => x.Name == "dog");
        }
    }
}
