# Part 4 - How to use the Automatic Not a Dog Application

Does our dog detector work correctly?! This is the moment of truth.

## Upload new images

There are many different ways to upload files into the Azure blob storage. But for today let's use the portal.

1. In the Azure portal, select the storage account that you deployed.
1. In the lower right section click on **Blobs**

    ![blobs][blobs]

1. That will display the containers. Click on **images**.
1. Click the Upload button.
1. From the new panel on the right; click the button to find a file locally.
1. Click the button **Upload**.

    ![upload][upload]

1. Repeat the steps with all kinds of pictures.

## Validation

To validate that our function really only accepts pictures of dogs, let's get back to the website and refresh the page images.

![final][final]

---

## Learn more

You could also execute your function locally!

In Visual studio, put a breakpoint at line 42 `if(IsDog(results))`. The variable `result` contains the information returned by the Vision API.

You will be able to see all the tags / metadata sent.

[blobs]: medias/blobs.png "Click on Blobs"
[upload]: medias/upload.png "Upload"
[final]: medias/final.png "Upload"
