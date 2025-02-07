using System.Diagnostics;
using Demo.Models;
using Demo.Services.OGImageService;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOGImageService _ogImageService;
        public HomeController(IOGImageService _ogImageService)
        {
            this._ogImageService = _ogImageService;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public async Task<IActionResult> Page(string pageName)
        {
            ViewData["Title"] = pageName;
            ViewData["OGImageUrl"] =await _ogImageService.GetOGImage(pageName);
            return View();
        }
       
    }
}
