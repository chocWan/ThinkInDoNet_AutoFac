using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkInDoNet_AutoFac.Services
{
    public class ReadService : IReadService
    {
        public string GetContent(string fnumber)
        {
            return $"the number is {fnumber}";
        }
    }
}
