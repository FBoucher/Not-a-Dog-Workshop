# Not a Dog Workshop

This workshop is for beginners who would like to learn more about the cloud and the try some services available. Today artificial intelligence (AI) can benefit a lot of our application and most of the time it's easier then we think to implement it.

During this workshop you will deploy and complete a web application able to detect when picture are or not dogs and keep our images folder "clean". We call that application *The automatic Not a Dog application*.

> We are using dog as topics, but you can defenetly extend the capability of the application to manage picture of an event, the office, or a group. You could automatically generate tags and so many things...

## What you will need before the Workshop

To get the best of this Not a Dog Workshop, we **strongly** suggest that you prepare your station with all the required software. Nothing complicated and all the tools that we are going to use during the workshop supports macOS, Linux, and Windows - so you can hit the ground running, no matter the platform.

[How to install all the prerequisites](workshop-prerequisites.md)

## Part 1 - Deploy the solution to Azure

To get started we will deploy a simple Asp.Net Core MVC application to Azure. This website will display all the images contain in our Azure storage.

There is many different ways to deploy to Azure. You can deploy directly development tools like Visual Studio, build a Continuous Integration and Continuous Deployment (CI-CD).  For today's workshop everything is prepared for you. Click the following link to get started.

**[Deploying the startup solution to Azure](Part1-Deploying-the-startupSolution.md)**

## Part 2 - Creating the Cognitive Services

The goal of this step is to create a Cognitive Service, and use it's Vision API to detect dogs in our images.

**[How to Create an Cognitive Services](Part2-Create-an-Cognitive-Services.md)**


## Part 3 - Build and Deploy The Azure Function

Now that we have some Artificial Intelligence (AI) that will analyze the images, we need some code that could be executed every time a new picture is added.

To do this we will use an Azure Function. 

**[Build and Deploy The Azure Function](Part3-Build-and-Deploy-The-Azure-Function.md)**

## Part 4 - It's time to play!

Does our Dog detector will work correctly?! It's time to test our application...

**[How to use the Automatic Not a Dog Application](Part4-Its-time-to-play.md)**
