using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotADog.Services;

namespace NotADog.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IBlobStorageManager _blobStorageManager;

        public ImagesController(IBlobStorageManager blobStorageManager)
        {
            _blobStorageManager = blobStorageManager ?? throw new ArgumentNullException(nameof(blobStorageManager));
        }

        public IActionResult Index()
        {
            var files = _blobStorageManager.GetFiles("images").Select(item => item.Uri).ToList();
            
            if(files.Count == 0){
                _blobStorageManager.UploadFile("https://github.com/FBoucher/Not-a-Dog-Workshop/raw/master/medias/dogs-way.jpg", "images");
                _blobStorageManager.UploadFile("https://github.com/FBoucher/Not-a-Dog-Workshop/raw/master/medias/tesla-cat.jpg", "images");
                files = _blobStorageManager.GetFiles("images").Select(item => item.Uri).ToList();
            }

            ViewBag.Files = files;
            return View();
        }
    }
}