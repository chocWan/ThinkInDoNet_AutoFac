using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;
using AutoFac_NetCoreMVC.Models;
using AutoFac_NetCoreMVC.Services;

namespace AutoFac_NetCoreMVC.Controllers
{
    public class HomeController : Controller
    {

        //构造方法注入
        //private IReadService readService;
        //public HomeController(IReadService _readService)
        //{
        //    readService = _readService;
        //}

        //属性注入
        public IReadService readService { set; get; }
        private ILog log = LogManager.GetLogger(Startup.LogRepository.Name, typeof(HomeController));

        public IActionResult Index()
        {
            string res = readService.GetContent("choc test");
            var res2 = readService.GetContents();
            log.Info(res);//it does not work!
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
