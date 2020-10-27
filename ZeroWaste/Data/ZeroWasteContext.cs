
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZeroWaste.Models;

namespace ZeroWaste.Data
{
    public class ZeroWasteContext : IdentityDbContext<IdentityUser>
    {

        public ZeroWasteContext(DbContextOptions<ZeroWasteContext> options)
            : base(options)
        {
        }

        public DbSet<Allergy> Allergies { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Keyword> Keywords { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<NutritionalType> NutritionalTypes { get; set; }

        public DbSet<Recipie> Recipies { get; set; }

        public DbSet<ZWMember> ZWMembers { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseMySQL("server=192.168.1.5;port=3306;database=todolist;user=zero;password=123456");

    }



}
