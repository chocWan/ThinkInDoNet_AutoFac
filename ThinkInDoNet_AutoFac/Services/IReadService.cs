using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkInDoNet_AutoFac.Models;

namespace ThinkInDoNet_AutoFac.Services
{
    public interface IReadService
    {
        string GetContent(string fnumber);
    }
}
