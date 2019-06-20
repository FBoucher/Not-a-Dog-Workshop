# Part 2 - Creating the Cognitive Services

In the previous section, *[we deployed a website to Azure](Part1-Deploying-the-startupSolution.md)* that display all the images in our blog storage. The goal of this step is to create a [Cognitive Service](https://azure.microsoft.com/en-ca/services/cognitive-services?WT.mc_id=tohack-github-frbouche), and use it's Vision API to detect dogs in our images.

> The Cognitive Services are a great way to infuse your apps, websites and bots with intelligent algorithms to see, hear, speak, understand and interpret your user needs through natural methods of communication. Transform your business with AI today.[Lear more...](https://azure.microsoft.com/en-ca/services/cognitive-services?WT.mc_id=tohack-github-frbouche)

## Azure Portal

The most common tool when we start with Azure, or when we explore new feature is the Azure portal. It's always updated and very easy to use.

Navigate to [https://portal.azure.com](https://portal.azure.com/#home)

![azurePortal][azurePortal]

Let's do a quick tour. 

In the top left corner (A) you have:
- the big green "+" button to create any resources.
- the home button that brings you back to this view.
- the dashboard button that brings you to you custom dashboards that you can share with others.
- All Services will display the list of all services group by family. From there you can narrow the selection an see a list of your resources matching your type selection.

Just under it, you have the favorites (B). This list is completely configurable. Just like bookmarks, by clicking on one of them you will see all the instance of a certain type listed for you.

In the top of the screen in the middle there the search bar (C). It will search through type, instance and even documentation!

Just on the right side of the search bar you have a few useful button:

- Cloud Shell, a fully functional terminal
- I filter to change what you see in the portal. Very useful when you have access to multiple subscription.
- The notification list.
- Settings, where you can change the language, color of the portal beside many other things
- Help, and  Feedback

Finally in the top right corner it's you (E) and a way to access all the account settings.

## Let's get started.

Now that we know the portal, let's create an instance of Cognitive Service. 

1. Click the "**+**" button from the top left corner.
1. in the search bar, type *vision*
1. From the list select **Computer Vision**

    ![typeVision][typeVision]
1. Click the **Create** button.

It's now time to select the properties of your Vision API. 

1. Give it a **unique name**. Be sure the there is a little green check at the right of the textbox, meaning that is is valid.
1. Validate if it's in the good subscription. It should be the same used previously to deploy the website.
1. You can select any location. It's recommended to select the same for all the resources to get the best performance.
1. Select F0 (aka Free) for the Pricing tier.
1. Select the same resource group that was created for the previous deployment.

It should look like this. Click the Create button.

![createVision][createVision]

After a few seconds, the *Cognitive Services - Computer Vision* resource should be created.

## Get the API Endpoint and Key

To be able to use this API we will need to get it's endpoint end the key. 

1. From the left panel, click on *Resource groups*. This will list all the groups in your subscription.
1. Click on your resource group (ex: Hackdemo).
1. Once more, we are in the resource group with the website, storage account and service plan. This time there is a new resource available. Click on your Computer Vision (ex: smartVision)

    ![selectVision][selectVision]

1. From the left panel select **Overview**. In the top-right section of that blade you will found the **Endpoint**. Note that, we will need it later.

    ![visionEndpoint][visionEndpoint]

1. Now we need the access Key. To find it, select **Key** from the left panel, and note one of the two keys.

    ![visionKey][visionKey]

    > You have two key for security purposes. This way you can update your security without stopping your services.


## Coming Next

You have now completed this part of the workshop. **You can continue with Part 3: [Build and Deploy The Azure Function](Part3-Build-and-Deploy-an-Azure-Function.md)**.

---

## Learn more

...more to come...




[azurePortal]: medias/azurePortal.png "The Azure Portal"
[typeVision]: medias/typeVision.png "Create a Vision"
[createVision]: medias/createVision.png "Create a Vision"
[selectVision]: medias/selectVision.png "Select Vision Resource"
[visionKey]: medias/visionKey.png "Get Vision Key"
[visionEndpoint]: medias/visionEndpoint.png "Get Vision endpoint"
