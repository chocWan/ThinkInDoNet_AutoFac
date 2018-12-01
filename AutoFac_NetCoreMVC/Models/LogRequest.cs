using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFac_NetCoreMVC.Models
{
    public class LogRequest:Entity
    {
        [Key]
        public int FId { set; get; }
        public string FName { set; get; }
        public string FRequestUrl { set; get; }
        public string FRequestType { set; get; }
        public string FParameters { set; get; }
        public string FMessage { set; get; }
        public string FDetails { set; get; }
        public string FIPAddress { set; get; }
        public string FRequestUser { set; get; }
        public DateTime FRequestTime { set; get; }
    }
}
