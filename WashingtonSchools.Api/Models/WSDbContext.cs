using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WashingtonSchools.Api.Models
{
  public class WSDbContext : DbContext
  {
    public WSDbContext(DbContextOptions<WSDbContext> options) : base(options)
    {      
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      var school = School.CreateSample();

      modelBuilder.Entity<School>().HasData(school);

    }

    public DbSet<School> Schools { get; set; }
    public DbSet<Student> Students { get; set; }
  }
}
