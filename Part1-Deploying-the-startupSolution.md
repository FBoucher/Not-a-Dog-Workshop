
# Part 1 - Deploying the Startup Solution to Azure

To get started we will deploy a simple Asp.Net Core MVC application to Azure. There are many different ways to deploy to Azure; from development tools like Visual Studio to a complete Continuous Integration and Continuous Deployment (CI-CD). Today we will use the **Deploy to Azure** button.

## Configuring the Deployment

1. Click the **Deploy to Azure** button.

    <a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FFBoucher%2FNot-a-Dog-Workshop%2Fmaster%2Fdeployment%2FdeployAzure.json?WT.mc_id=tohack-github-frbouche" target="_blank"><img src="https://azuredeploy.net/deploybutton.png"/></a>

1. You will be prompted to login in Azure. Select the Microsoft account (Outlook, Hotmail) to access your Azure subscription.

    ![PickSubscription][PickSubscription]

1. This will bring you to the deployment form. It's mostly completed, so let's have a look at what is presented here.

    ![CustomDeployment][CustomDeployment]

    - **Subscription**: Display the subscription where the resources will be deployed. You can change it if you are not happy with the one selected.
    - **Resource group**: A **Resource group** is a logical group. We can put any resources together in it. However, most of the best practices will recommend putting the resources that have the same life cycle in a resource group. Click the **Create new** button and enter the name of YOUR resource group (ex: HackDemo). Then click the *Ok* button.
    - **Location**: There are many different locations. Usually you would pick a location that is close to your user or your data. For this workshop it doesn't matter, you can keep East US or change it if you want.
    - **Web App Name**: This name will be used as the base to name all the resources deployed. You can change it if you wish. Note that the name must be shorter than 12 characters.
    - **Branch Name**: This is a reference to the GitHub branch from where the code will by pulled. You should keep it at **master**.

1. Check the Agreement checkbox.
1. Click the Purchase button.

## Deploying the solution

The resources are now being deployed to Azure. You can follow the process by clicking the notification (1) that will popup in the top right corner. If you missed it, you can show the notification list by clicking the bell button (2) also in the top right corner.

![clickNotification][clickNotification]

After a few (2-5) minutes, your deployment should be completed.

![deploymentCompleted][deploymentCompleted]

**CONGRATULATIONS**, you just deployed your first Web application in Azure!

## Validating the Deployment

Let's have a look to the resources that we just deployed. Click the Resource group link (here it's Hackdemo), to display the Resource Group blade (aka page).

![resourceGroup][resourceGroup]

Here you will have access to all the information related to this specific Resource Group. In the section (A) there are all the *options* like Deployments and Policies.

In the Section (B), this is where the resources contained in this specific resource group are listed.  You should have three resources; an App Service, a Service Plan and a Storage account.

1. Click on the App Service to open the webapp blade.
1. Same principle here, options on the left and details on the right. For now let's see what the website looks like.
   - In the top-right section of the blade you will find the URL, click on it to open the web page.
     ![websiteURL][websiteURL]
1. There it is! Very basic, but this is all we need for today's workshop. In the top menu click on **Images**.
     ![website][website]

> The first time you get to this page some images are loaded, it’s normal that it takes more time.

The website displays in a list all images available in our storage.  The intention is to have only pictures of dogs. As you can see there is a picture of a cat in our dog images folder.

The goal of this workshop is to build an automatic solution that will discard all pictures that are not dogs.

### Coming Next

You have now completed this part of the workshop. **You can continue with Part 2: [Create an Cognitive Services](Part2-Create-an-Cognitive-Services.md)**.

---

## Learn more

You will notice that all services have the same beginning **hackdogdemo**. This is the value you provide in the configuration.

Then for all of then there is a "blob" of letter **6l3th**.  Of course, yours will be different because this is a unique string generated to be sure all our names are unique. If more then one person is trying to deploy a website with the *hackdogdemo*, the second will have an error saying that the name is already taken.

For the service plan, and the storage account we also added some short suffix to identify them.

All those settings are defined in the Azure Resource Manager (ARM) template that was used in the deployment. The ARM template is defined in the file [deployAzure.json](deployment/deployAzure.json). It is a very strong tool to deploy to Azure. You can learn more about ARM templates [here.](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-overview?WT.mc_id=tohack-github-frbouche)

The deployment used by the Deploy to Azure button, uses this ARM template. This will create the three resources we need to get started in our project.

To get the code into our App Service (aka. website) we configure the repository of the AppService to be this GitHub repo. This is done at line 91 of the `deployAzure.json`

```json
{
    "apiVersion": "2018-02-01",
    "name": "web",
    "type": "sourcecontrols",
    "dependsOn": [
        "[resourceId('Microsoft.Web/sites', variables('webAppName'))]"
    ],
    "properties": {
        "repoUrl":"https://github.com/FBoucher/Not-a-Dog-Workshop.git",
        "branch": "[parameters('branchName')]",
        "publishRunbook": true,
        "IsManualIntegration": true
    }
}
```

Because this GitHub repo does not only contain the project we needed to specify to Kudu (Azure background interface name) where it could find the project.

This is done in the [.deployment](.deployment) file available at the root. This file is used to customize your build. It could redirect to a script but in this case we are pointing the project to deploy.

```
[config]
project = NotADogDemo/DogDemo.csproj
```

You can learn more about the Kudu interface [here](https://github.com/projectkudu/kudu/wiki/Customizing-deployments).

[PickSubscription]: medias/PickSubscription.png "Select your account"
[CustomDeployment]: medias/CustomDeployment.png "Complete the custom deployment form"
[clickNotification]: medias/clickNotification.png "Click the notification"
[deploymentCompleted]: medias/deploymentCompleted.png "Deployment is Complete"
[resourceGroup]: medias/resourceGroup.png "Resource Group blade"
[websiteURL]: medias/websiteURL.png "Website URL"
[website]: medias/website.png "Website Not a Dog demo"
