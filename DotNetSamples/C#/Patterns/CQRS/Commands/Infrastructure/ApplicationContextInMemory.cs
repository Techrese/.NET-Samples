using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationContextInMemory : DbContext
    {
        public DbSet<Part> Parts { get; set; }

        public DbSet<PartLines> Lines { get; set; }

        public ApplicationContextInMemory(DbContextOptions options)
            :base(options)
        {
            LoadParts();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>()
                .HasOne(x => x.PartLines)
                .WithMany(x => x.Parts);
        }
        
        public void LoadParts()
        {
            var parts = new List<Part>()
            {
                new Part()
                {
                    Id = Guid.NewGuid(),
                    Name = "Connector-1-pin", 
                    Description = "connector with 1 pin"
                },
                new Part()
                {
                    Id = Guid.NewGuid(),
                    Name = "Connector-2-pin",
                    Description = "connector with 2 pins"
                },
                new Part()
                {
                    Id = Guid.NewGuid(),
                    Name = "Connector-3-pin",
                    Description = "connector with 3 pins"
                },
                new Part()
                {
                    Id = Guid.NewGuid(),
                    Name = "Connector-4-pin",
                    Description = "connector with 4 pins"
                },
                new Part()
                {
                    Id = Guid.NewGuid(),
                    Name = "Connector-5-pin",
                    Description = "connector with 5 pins"
                },
                new Part()
                {
                    Id = Guid.NewGuid(),
                    Name = "Connector-6-pin",
                    Description = "connector with 6 pins"
                },
                new Part()
                {
                    Id = Guid.NewGuid(),
                    Name = "Connector-7-pin",
                    Description = "connector with 7 pins"
                },
                new Part()
                {
                    Id = Guid.NewGuid(),
                    Name = "Connector-8-pin",
                    Description = "connector with 8 pins"
                },
                new Part()
                {
                    Id = Guid.NewGuid(),
                    Name = "Connector-9-pin",
                    Description = "connector with 9 pins"
                },
                new Part()
                {
                    Id = Guid.NewGuid(),
                    Name = "Connector-10-pin",
                    Description = "connector with 10 pins"
                },

            };
            Parts.AddRange(parts);
            base.SaveChanges();
        }
    }
}
