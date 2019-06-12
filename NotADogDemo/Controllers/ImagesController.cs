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
            ViewBag.Files = files;
            return View();
        }
    }
}