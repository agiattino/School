using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace App
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=app.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var Students = new Student[] {
                new Student { Id = 1, FirstName = "Laurie", LastName = "Logger", Age=13,  ClassOf=Student.Classification.Freshman},
                new Student { Id = 2, FirstName = "Margert", LastName = "Mury",Age=15, ClassOf=Student.Classification.Sophomore},
                new Student { Id = 3, FirstName = "Peter", LastName = "Piemont",Age=16, ClassOf=Student.Classification.Junior},
                new Student { Id = 4, FirstName = "Frank", LastName = "Folly",Age=17, ClassOf=Student.Classification.Senior},

            };

            modelBuilder.Entity<Student>().HasData(Students);

            var grades = new Grade[] {
                new Grade { Id = 1, StudentId = 1, CourseName = "Cooking With Gas" ,   grade=.70},
                new Grade { Id = 2, StudentId = 2,  CourseName = "Cooking With Gas" ,   grade = .89},
                new Grade { Id = 3, StudentId = 3,  CourseName = "Cooking With Gas",    grade = .75},
                new Grade { Id = 4, StudentId = 3,  CourseName = "Wood Shop",           grade =.75},
                new Grade { Id = 5, StudentId = 3,  CourseName = "Data Base Design",    grade =.75},
                new Grade { Id = 6, StudentId = 3,  CourseName = "Introduction to C# ", grade =.75},

            };

            modelBuilder.Entity<Grade>().HasData(grades);

            base.OnModelCreating(modelBuilder);
        }
    }
}