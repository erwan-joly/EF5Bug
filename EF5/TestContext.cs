using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace EF5
{
    public class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TestObject> TestObjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("User ID=postgres;Password=password;Host=127.0.0.1;Port=5432;Database=postgres;", o => o.UseNodaTime());
    }

    public class TestObject
    {
        [Key]
        public Guid Key { get; set; }
        public LocalDate? ADate { get; set; }
    }
}
