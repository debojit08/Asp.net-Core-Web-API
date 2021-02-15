using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI
{
    public class studentDBContext:DbContext
    {
        public studentDBContext(DbContextOptions<studentDBContext> options)
            :base(options)
        {

        }
        public DbSet<studentInfo> studentTable { get; set; }
    }
}
