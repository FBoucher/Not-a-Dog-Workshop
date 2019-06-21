# Part 4 - How to use the Automatic Not a Dog Application

Does our Dog detector is working correctly?! This is the moment of truth.

## Upload new images

There is many different way to upload files into the Azure blob storage. But for today let's use the portal.

1. In the Azure portal, select your storage account that you deployed.
1. In the lower right section click on **Blobs**

    ![blobs][blobs]

1. That will display the containers. Click on **images**.
1. Click the Upload button.
1. From the new panel on the right click the button to find a file locally.
1. Click the button Upload.

    ![upload][upload]

1. Repeat the steps as with all kind of picture.

## Validation

To validate that our function really only accept picture of dogs, Let's get back to the Website and refresh the pages images.

![final][final]





[blobs]: medias/blobs.png "Click on Blobs"
[upload]: medias/upload.png "Upload"
[final]: medias/final.png "Upload"
