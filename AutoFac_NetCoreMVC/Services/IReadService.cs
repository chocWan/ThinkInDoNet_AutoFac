using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFac_NetCoreMVC.Models;

namespace AutoFac_NetCoreMVC.Services
{
    public interface IReadService
    {
        string GetContent(string fnumber);
    }
}
