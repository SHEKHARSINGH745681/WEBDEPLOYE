using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WEBDEPLOYE.Models;

namespace WEBDEPLOYE.DATA
{
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)  
            {
            }

            public DbSet<User> Users { get; set; } 
        }
}


