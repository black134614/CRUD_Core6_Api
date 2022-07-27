using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Core6_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Core6_Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base (options)
        {
            
        }

        public virtual DbSet<SuperHero> SuperHeroes {get; set;}
    }
}