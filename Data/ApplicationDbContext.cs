using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoccerRead.Models;
using SoccerRead.Models.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerRead.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<MainComment> MainComments { get; set; }
        public DbSet<SubComment> SubComments { get; set; }
    }
}
