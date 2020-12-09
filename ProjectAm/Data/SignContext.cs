using Microsoft.EntityFrameworkCore;
using ProjectAm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAm.Data
{
    public class SignContext : DbContext
    {
        public SignContext(DbContextOptions<SignContext> options)
            : base(options)
        {
        }

        public DbSet<Sign> Users { get; set; }
    }
}
