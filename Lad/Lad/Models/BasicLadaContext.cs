using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Lad.Models
{
    class BasicLadaContext : DbContext
    {
        public DbSet<Section> Sections { get; set; }
        public DbSet<Learning> Learnings { get; set; }
        public DbSet<Achivment> Achivments { get; set; }
    }
}
