# Part 3 - Build and Deploy The Azure Function

Now that we have some Artificial Intelligence (AI) that will analyze the images, we need some code that could be executed every time a new picture is added.

To do this we will use an Azure Function. 

> The Function are part of the serverless offer of Microsoft. They provide an efficient way to execute code at scale without being expensive. [To learn more about Azure Function here](https://azure.microsoft.com/en-ca/services/functions/?WT.mc_id=tohack-github-frbouche).

## Creating the Function App

Prior to the workshop you should have [installed all the prerequisites](workshop-prerequisites.md). If it's not done now it's time. 

Let's open Visual Studio Code (aka VSCode). From the left menu bar select the **Azure** icon to open the Azure Function Extension.

![functionExtension][functionExtension]

To create a Function App, click on the first icon (the folder with a lightning bolt).

1. Create a new local folder and name it **HackDemo-Func**
1. When prompt for the language, select C#.
1. When Prompt for the project first function, select **Skip for now**

    ![skipForNow][skipForNow]

1. Finally select the **Open in current window** option.

It may takes a few second while VSCode build set all your project. Once it's done you will have a few files and folder.  We are now ready to create our Azure Function.

## Creating a DogDetector Azure Function 

There is many different type of Azure Function, or many different ways to interact with it. In this workshop what we need is a Function that will get triggered every time a new image is uploaded into our Azure Blob Storage. We need a Blob trigger.

1. From the Azure Function extension, click on the second icon (the lightning bolt with a little + sign).
1. Select **BlobTrigger** as template.
1. Enter **DogDetector** as function name.
1. Enter **DogDemo.Function** as namespace.
1. Enter **AzureWebJobsStorage** as settings from "local.settings.json"
1. The name of our container is "images", so the path that our function will monitor is also **images**. Enter Images.

You should have a warning popup at this time. Since we won't debug it locally, we can **skip it for now**.

![warningStorage][warningStorage]

## Add the missing references

Before we add some code inside the Azure Function let's add some requirement features. Let's first start by adding some package we will need. Look into the file `HackDemo-Func.csproj`. Currently you should have only one `<PackageReference>`, referencing the `Microsoft.NET.Sdk.Functions` and `Microsoft.Azure.WebJobs.Extensions.Storage`. 

Let's add a few more.

Open the terminal, from the top menu **Terminal** or with the shortcut ( Ctrl + \` ). Be sure you are in the `DogDemo-FuncApp` folder, and enter the following command.

    dotnet add package Newtonsoft.Json

If you look again the file `HackDemo-Func.csproj`, you will see that the package is now referenced. 

Repeat the previous command for the package 

    dotnet add package Microsoft.Azure.CognitiveServices.Vision.ComputerVision

and 

    dotnet add package Microsoft.Azure.WebJobs.Script.ExtensionsMetadataGenerator
 
## Add the code inside the Azure Function

Let's replace all the code of the `DogDetector.cs` by the following. (The file is also available [here](snippets/DogDetector.cs))

```csharp

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

```

You can test to see if your solution combile by executing the following command in the terminal:

    dotnet build

You may have some yellow warning message about Newtonsoft.Json version, search or a green Build succeeded.

![buildSucceeded][buildSucceeded]

## Deploying the Function App to Azure

...


## Configuring the Azure Function

...


## Coming Next

You have now completed this part of the workshop. **You can continue with Part 4: **[How to use the Automatic Not a Dog Application](Part4-Its-time-to-play.md)**.

---

## Learn more

...more to come...




[functionExtension]: medias/functionExtension.png "The Azure Function Extension"
[skipForNow]: medias/skipForNow.png "Skip For Now"
[warningStorage]: medias/warningStorage.png "Warning"
[buildSucceeded]: medias/buildSucceeded.png "Build Succeeded"

