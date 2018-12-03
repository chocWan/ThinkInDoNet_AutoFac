using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoFac_NetCoreMVC.Models;
using AutoFac_NetCoreMVC.Services;
using AutoFac_NetCoreMVC.Repositories;
using NLog;
using AutoFac_NetCoreMVC.Helper;

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
        public IReadService ReadService { set; get; }
        public IRepository<LogRequest> LogRequestRepository { set; get; }
       
        public IActionResult Index()
        {
            string res = ReadService.GetContent("choc test");
            var res2 = ReadService.GetContents();
            LogHelper.GetLogger().Debug(res + "debug");
            LogHelper.GetLogger().Info(res + "info");
            LogHelper.GetLogger().Error(res + "error");
            LogRequest logRequest = new LogRequest { FName= "FName", FDetails= "FDetails", FIPAddress = "FIPAddress", FMessage = "FMessage", FParameters = "FParameters", FRequestTime = DateTime.Now,FRequestType = "FRequestType", FRequestUrl = "FRequestUrl", FRequestUser = "FRequestUser" };
            LogHelper.LogRequest(logRequest);
            var logRes = LogRequestRepository.GetAllList();
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
