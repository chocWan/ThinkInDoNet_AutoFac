using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkInDoNet_AutoFac.Models;

namespace ThinkInDoNet_AutoFac.Context
{
    public class RaeClassContext:DbContext
    {
        public RaeClassContext(DbContextOptions<RaeClassContext> options)
            : base(options)
        {
        }

        public DbSet<ReadContent> ReadContentSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //自定义表名
            modelBuilder.Entity<ReadContent>().ToTable("ReadContent", "dbo");

            base.OnModelCreating(modelBuilder);
        }
    }
}
