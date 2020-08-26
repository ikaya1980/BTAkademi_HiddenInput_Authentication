using System;
using Microsoft.EntityFrameworkCore;
using ornekWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ornekWeb.Data
{
    public class WebDbContext:DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
        {

        }

        public DbSet<Firm> firms { get; set; }
        public DbSet<QuestionAnswer> questionanswers { get; set; }
        public DbSet<User> Users { get; set; } 

    }
}
