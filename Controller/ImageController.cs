using Microsoft.AspNetCore.Mvc;
using Vecto.Models;
using Vecto.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;


namespace Vecto.Controller
{
    public class ImageController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IImageProcessingService _imageProcessingService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ImageController(IImageProcessingService imageProcessingService, IWebHostEnvironment hostingEnvironment)
        {
            _imageProcessingService = imageProcessingService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ImageProcessingModel> model = new List<ImageProcessingModel>
                {
                    new ImageProcessingModel { ImageFile = null, SelectedEffects = new List<string>(), Radius = 0, Size = 0 },
                    new ImageProcessingModel { ImageFile = null, SelectedEffects = new List<string>(), Radius = 0, Size = 0 },
                    new ImageProcessingModel { ImageFile = null, SelectedEffects = new List<string>(), Radius = 0, Size = 0 }
                };
            return View(model);
        }

        [HttpPost]
        public IActionResult ProcessImages(List<ImageProcessingModel> models)
        {
            if (models != null)
            {
                foreach (var model in models)
                {
                    if (model.ImageFile != null && model.ImageFile.Length > 0)
                    {
                        string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "logos");
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }
                        string contentType = model.ImageFile.ContentType;
                        string fileType = contentType.Split('/')[1];
                        string uniqueFileName = "logo" + "." + fileType;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            model.ImageFile.CopyTo(fileStream);
                            Console.WriteLine($"Processing image: {model.ImageFile.FileName}");
                        }

                    }

                    Console.WriteLine($"Selected Effects: {string.Join(", ", model.SelectedEffects)}");
                    Console.WriteLine($"Radius: {model.Radius}");
                    Console.WriteLine($"Size: {model.Size}");
                }

                return View("Index");
            }

            return RedirectToAction("Error");
        }
    }
}
