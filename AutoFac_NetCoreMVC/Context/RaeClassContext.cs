using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFac_NetCoreMVC.Models;

namespace AutoFac_NetCoreMVC.Context
{
    public class RaeClassContext:DbContext
    {
        public RaeClassContext(DbContextOptions<RaeClassContext> options)
            : base(options)
        {
        }

        public DbSet<ReadContent> ReadContentSet { get; set; }
        public DbSet<LogRequest> LogRequestSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //自定义表名
            modelBuilder.Entity<ReadContent>().ToTable("ReadContent", "dbo");
            modelBuilder.Entity<LogRequest>().ToTable("LogRequest", "dbo");

            base.OnModelCreating(modelBuilder);
        }
    }
}
