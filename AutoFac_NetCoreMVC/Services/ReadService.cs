using AutoFac_NetCoreMVC.Models;
using AutoFac_NetCoreMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFac_NetCoreMVC.Services
{
    public class ReadService : IReadService
    {
        public IRepository<ReadContent> readRepository;
        public string GetContent(string fnumber)
        {
            return $"the number is {fnumber}";
        }
        public List<ReadContent> GetContents()
        {
            return readRepository.GetAllList();
        }
    }
}
