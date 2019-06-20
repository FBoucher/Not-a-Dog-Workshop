# What you will need before the Workshop

To get the best of this Not a Dog Workshop, we **strongly** suggest that you prepare your station with all the required software. Nothing complicated and all the tools that we are going to use during the workshop supports macOS, Linux, and Windows - so you can hit the ground running, no matter the platform.

# .NET Core

We will be creating a Web application in .NET Core. Therefore you will need the .NET Core Framework installed on your local machine. To validate if you already have it execute the following command in a terminal.

    dotnet --version

If you have a version equal or greater to 2.1 your are fine. Otherwise we invite you to download a more recent version. In a web browser, navigate to [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download). Select your OS between Windows, Linux, or MacOS and click the button Download .NET Core SDK

![dotnetcore][dotnetcore]

Once the installer is downloaded follow the instruction in run it.  When the install is complete re-execute the comment to validate that you have a version equal or greater to 2.1

# The Tools

## Visual Studio Code

![code][code]

Visual Studio Code is a lightweight source code editor developed by Microsoft for Windows, Linux and macOS. It includes support for debugging, embedded Git control, syntax highlighting, intelligent code completion, snippets, and code refactoring.

It's not a requirement but all labs will assume that you have it installed. To install Visual Studio Code, navigate to [code.visualstudio.com](https://code.visualstudio.com/?wt.mc_id=vscom_downloads), and select your platform.

![code-select][code-select]

### Extension

One of the strengths of Visual Studio Code is all its extensions.  During the following Labs, we will use some of them to make things easier.

Installing an extension is very simple and it's done directly from VSCode. Follow these instruction:

* Open VSCode and from the left menu and select the Extensions (Ctrl+Shift+X).
* Type `Azure Functions` into the search bar at the top of the Extensions Marketplace panel that just opened.
* From the search result, select `Azure Functions`.
* Click on the little *Install* green button on the side of the extension to proceed with installation.

Congratulation, you just installed your first extension.  

# Accounts

## Azure Subscription

Having an Azure subscription is mandatory to be able to do the TOHacks Workshop. If you don't own an Azure subscription already, you can create your **free** account today. It comes with 200$ credit, so you can experience almost everything without spending a dime. 

[Create your free Azure account today](https://azure.microsoft.com/en-us/free?WT.mc_id=globalazure-github-frbouche)

![freeAzure][freeAzure]



[code]: medias/code-screenshot.png "Visual Studio Code screenshot"
[code-select]: medias/code-select.jpg
[code-extensions]: medias/code-extensions.jpg
[freeAzure]: medias/freeAzure.png
[azureDevOps]: medias/azureDevOps.png
[dotnetcore]: medias/dotnetcore.png



