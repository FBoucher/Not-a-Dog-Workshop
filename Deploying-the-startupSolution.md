
# Deploying the startup solution to Azure

To get started we will deploy a simple Asp.Net Core MVC application to Azure. There is many different ways to deploy to Azure from development tools like Visual Studio to a complete Continuous Integration and Continuous Deployment (CI-CD). Today we will the the **Deploy to Azure** button.

1. Click the **Deploy to Azure** button.

    <a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FFBoucher%2FNot-a-Dog-Workshop%2Fmaster%2Fdeployment%2FdeployAzure.json" target="_blank"><img src="https://azuredeploy.net/deploybutton.png"/></a>

1. You will be prompt to login in Azure. Select the Microsoft account (outlook, hotmail) to access your Azure subscription.

    ![PickSubscription][PickSubscription]

1. This will bring you to the Deployment form. It's mostly completed, let's have a look to what is presented here.

    ![CustomDeployment][CustomDeployment]

    - **Subscription**: Display the subscription where the resources will be deploy. You can change it if you are not happy with the one selected.
    - **Resource group**: A **Resource group** is a logical group. We can put any resources together in it. However, most the best practice will recommend to put in a resource group the resources that have the same life cycle. Click the **Create new** button and enter the name YOUR resource group (ex: HackDemo). Then click the *Ok* button.
    - **Location**: There is many different location. Usually you would pick a location that is close to your user, or your data. For this workshop it doesn't matter you can keep East US or change it if you want.
    - **Web App Name**: This name will be use as the base to named all the resources deployed. You can change it if you wish. Note that the name must be shorter then 12 characters.
    - **Branch Name**: This is a reference to the GitHub branch where the code will by pull. You should keep it to **master**.

1. Check the Agreement checkbox.
1. Click the Purchase button. 

# Deploying the solution

The resources are now being deploy to Azure. You can follow the process by clicking the notification (1) that will popup in the top right corner. If you missed it you can show the notification list by clicking the bell button (2) also in the top right corner.

![clickNotification][clickNotification]

After a few (2-5) minutes, your deployment should be completed.

![deploymentCompleted][deploymentCompleted]

**CONGRADULATION**, you just deploy your first Web application in Azure!

## Validating our success

Let's have a look to the resources that we just deployed. Click the Resource group (here it's Hackdemo) link, to display the Resource Group blade (aka page).

![resourceGroup][resourceGroup]

Here you will have access to all the information related to this specific Resource Group. In the section (A) there is all the *options* like Deployments and Policies.

In the Section (B), this is where the resources contained in this specific resource groups are listed.  You should have three resources an App Service, a Service Plan and a Storage account.





[PickSubscription]: medias/PickSubscription.png "Select your account"
[CustomDeployment]: medias/CustomDeployment.png "Complete the custom deployment form"
[clickNotification]: medias/clickNotification.png "Click the notification"
[deploymentCompleted]: medias/deploymentCompleted.png "Deployment is Complete"
[resourceGroup]: media/resourceGroup.png "Resource Group blade"
