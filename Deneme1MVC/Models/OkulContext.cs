using Deneme1MVC.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Deneme1MVC.Models
{
    public class OkulContext: IdentityDbContext<ApplicationUser>
    {
        public OkulContext() : base("OkulCon") { }
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ders> Dersler { get; set; }
    }
}