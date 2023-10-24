using ITManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITManagement.Data
{
    public class ApplicationITDbContect : IdentityDbContext<IdentityUser>
    {
        public ApplicationITDbContect(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Departament> Departaments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Project> Projects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Departament>().HasData(
                new Departament
                {
                    Id = 1,
                    Name = "IT",
                    DisplayDepartament = 1
                },
                new Departament
                {
                    Id = 2,
                    Name = "HR",
                    DisplayDepartament = 2
                },
                new Departament
                {
                    Id = 3,
                    Name = "Developers",
                    DisplayDepartament = 3
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Name = "Desk IT Management",
                    Description = " Best IT desk",
                    FinishProject =  new DateTime(2002, 2, 23),
                    EmployeeId = 1,
                    ImageUrl = "",

                },
                 new Project
                 {
                     Id = 2,
                     Name = "Bank Web Host",
                     Description = " Bank transaction online",
                     FinishProject = new DateTime(2007, 12, 5),
                     EmployeeId = 2,
                     ImageUrl ="",

                 });



            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Robert",
                    LastName = "Furdui",
                    DateOfHire = DateTime.Now,
                    DateOfBirth = new DateTime(1990, 5, 15),
                    DepartamentId = 1,
                    ImageUrl = "",
                    Salary = 3000,
                    Email = "rfurdui26@gmail.com",
                    StreetAdress = "Tech Aria 156 Street",
                    PhoneNumber = "3746736473",
                    PostalCode = "34234",
                    City = "Sebes",
                    State = "AB",
                    Country = "Roumania",


                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Mihai",
                    LastName = "Achimescu",
                    DateOfHire = DateTime.Now,
                    DateOfBirth = new DateTime(2002, 2, 23),
                    DepartamentId = 2,
                    ImageUrl = "",
                    Salary = 6000,
                    Email = "mihaiachi26@gmail.com",
                    StreetAdress = "Don Juan 156 Street",
                    PhoneNumber = "69586988765",
                    PostalCode = "45567",
                    City = "Sibiu",
                    State = "SB",
                    Country = "Roumania",


                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Jhon",
                    LastName = "Hank",
                    DateOfHire = DateTime.Now,
                    DateOfBirth = new DateTime(2000, 10, 12),
                    DepartamentId = 3,
                    ImageUrl = "",
                    Salary = 5600,
                    Email = "hank26@gmail.com",
                    StreetAdress = "Los Angeles 156 Street",
                    PhoneNumber = "7857487546584",
                    PostalCode = "99087",
                    City = "LogoRados",
                    State = "LR",
                    Country = "Armenia",


                });
        }
    }
}
