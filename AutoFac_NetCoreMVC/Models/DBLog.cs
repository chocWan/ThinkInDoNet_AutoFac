using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFac_NetCoreMVC.Models
{
    public class DBLog:Entity
    {
        public int FID { set; get; }
        public string Timestamp { set; get; }
        public string Callsite { set; get; }
        public string Loglevel { set; get; }
        public string Logger { set; get; }
        public string Message { set; get; }
        public string Exception { set; get; }
    }
}
