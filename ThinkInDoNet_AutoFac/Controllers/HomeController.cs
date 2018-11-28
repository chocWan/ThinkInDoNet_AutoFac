﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThinkInDoNet_AutoFac.Models;
using ThinkInDoNet_AutoFac.Services;

namespace ThinkInDoNet_AutoFac.Controllers
{
    public class HomeController : Controller
    {

        private IReadService readService;
        public HomeController(IReadService _readService)
        {
            readService = _readService;
        }

        public IActionResult Index()
        {
            string res = readService.GetContent("choc test");
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