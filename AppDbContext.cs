using Barroc_intens.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_intens;

internal class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerContactPerson> CustomerContactPersons { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<PackageProduct> PackageProducts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<CustomerAppointment> CustomerAppointments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            ConfigurationManager.ConnectionStrings["Database"].ConnectionString, ServerVersion.Parse("8.0.13"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, RoleName = "Admin" },
            new Role { Id = 2, RoleName = "CEO" },
            new Role { Id = 3, RoleName = "HeadFinance" },
            new Role { Id = 4, RoleName = "AdminFinance" },
            new Role { Id = 5, RoleName = "HeadSales" },
            new Role { Id = 6, RoleName = "Consultant" },
            new Role { Id = 7, RoleName = "headInkoop" },
            new Role { Id = 8, RoleName = "Inkoper" },
            new Role { Id = 9, RoleName = "MedewerkerMagazijn" },
            new Role { Id = 10, RoleName = "HeadMaintenance" },
            new Role { Id = 11, RoleName = "TechnicalService" },
            new Role { Id = 12, RoleName = "Planner" }
        );

        //products en category seeder
        var products = new List<Product>();
        var categories = new List<Category>();
        var appointments = new List<Appointment>();
        var customers = new List<Customer>();
        var contactPerson = new List<CustomerContactPerson>();

        categories.AddRange([
            new Category { Id = 1, Name = "Automaten" },
            new Category { Id = 2, Name = "Koffiebonen" }
        ]);

        products.AddRange([
            // Automaten
            new Product
                {
                    Id = 1,
                    Name = "All the Things Brew Are",
                    ProductNumber = 10000027,
                    LeaseCost = 599,
                    InstallCost = 349,
                    PricePerKilo = 0,
                    CategoryId = 1,
                    UnitsInStock = 24
                },
                new Product
                {
                    Id = 2,
                    Name = "Ob-La-Di Oblend-A",
                    ProductNumber = 10000028,
                    LeaseCost = 0,
                    InstallCost = 0,
                    PricePerKilo = 40,
                    CategoryId = 2,
                    UnitsInStock = 26
                },
            new Product
                {
                    Id = 201,
                    Name = "Barroc Intens Italian Light",
                    ProductNumber = 23456701,
                    UnitsInStock = 0,
                    LeaseCost = 499,
                    InstallCost = 289,
                    PricePerKilo = 0, // Niet van toepassing
                    CategoryId = 1
                },
                new Product
                {
                    Id = 202,
                    Name = "Barroc Intens Italian",
                    ProductNumber = 23456702,
                    UnitsInStock = 0,
                    LeaseCost = 599,
                    InstallCost = 289,
                    PricePerKilo = 0, // Niet van toepassing
                    CategoryId = 1
                },
                
                new Product
                {
                    Id = 203,
                    Name = "Barroc Intens Italian Deluxe",
                    ProductNumber = 23456703,
                    UnitsInStock = 2,
                    LeaseCost = 799,
                    InstallCost = 375,
                    PricePerKilo = 0, // Niet van toepassing
                    CategoryId = 1
                },
                new Product
                {
                    Id = 204,
                    Name = "Barroc Intens Italian Deluxe Special",
                    ProductNumber = 23456704,
                    UnitsInStock = 7,
                    LeaseCost = 999,
                    InstallCost = 375,
                    PricePerKilo = 0, // Niet van toepassing
                    CategoryId = 1
                },
                new Product
                {
                    Id = 13,
                    Name = "Barroc Intens Brew Pro",
                    ProductNumber = 23456701,
                    LeaseCost = 499,
                    InstallCost = 289,
                    PricePerKilo = 0, // Niet van toepassing
                    CategoryId = 1
                },
                new Product
                {
                    Id = 14,
                    Name = "Barroc Intens Brew Pro max plus",
                    ProductNumber = 23456701,
                    UnitsInStock = 1,
                    LeaseCost = 499,
                    InstallCost = 289,
                    PricePerKilo = 0, // Niet van toepassing
                    CategoryId = 1
                },
                new Product
                {
                    Id = 15,
                    Name = "Barroc Intens Brew Pro max plus ultra",
                    ProductNumber = 23456701,
                    UnitsInStock = 2,
                    LeaseCost = 499,
                    InstallCost = 289,
                    PricePerKilo = 0, // Niet van toepassing
                    CategoryId = 1
                },
                new Product
                {
                    Id = 16,
                    Name = "Barroc Intens Brew",
                    ProductNumber = 23456701,
                    UnitsInStock = 3,
                    LeaseCost = 499,
                    InstallCost = 289,
                    PricePerKilo = 0, // Niet van toepassing
                    CategoryId = 1
                },
                new Product
                {
                    Id = 17,
                    Name = "Barroc Intens Brew ii",
                    ProductNumber = 23456701,
                    UnitsInStock = 4,
                    LeaseCost = 499,
                    InstallCost = 289,
                    PricePerKilo = 0, // Niet van toepassing
                    CategoryId = 1
                },
                new Product
                {
                    Id = 18,
                    Name = "Barroc Intens Brew Pro iii",
                    ProductNumber = 23456701,
                    UnitsInStock = 2,
                    LeaseCost = 499,
                    InstallCost = 289,
                    PricePerKilo = 0, // Niet van toepassing
                    CategoryId = 1
                },
                new Product
                {
                    Id = 19,
                    Name = "Barroc Intens Brew iv",
                    ProductNumber = 23456701,
                    UnitsInStock = 1,
                    LeaseCost = 499,
                    InstallCost = 289,
                    PricePerKilo = 0, // Niet van toepassing
                    CategoryId = 1
                },
                // Koffiebonen
                new Product
                {
                    Id = 205,
                    Name = "Espresso Beneficio",
                    ProductNumber = 23912345,
                    UnitsInStock = 273,
                    LeaseCost = 0, // Niet van toepassing
                    InstallCost = 0, // Niet van toepassing
                    PricePerKilo = 21.60,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 206,
                    Name = "Yellow Bourbon Brasil",
                    ProductNumber = 23912346,
                    UnitsInStock = 320,
                    LeaseCost = 0, // Niet van toepassing
                    InstallCost = 0, // Niet van toepassing
                    PricePerKilo = 23.20,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 207,
                    Name = "Espresso Roma",
                    ProductNumber = 23912347,
                    UnitsInStock = 74,
                    LeaseCost = 0, // Niet van toepassing
                    InstallCost = 0, // Niet van toepassing
                    PricePerKilo = 20.80,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 208,
                    Name = "Red Honey Honduras",
                    ProductNumber = 23912348,
                    UnitsInStock = 37,
                    LeaseCost = 0, // Niet van toepassing
                    InstallCost = 0, // Niet van toepassing
                    PricePerKilo = 27.80,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 9,
                    Name = "Panama Joe's Blend",
                    ProductNumber = 23912348,
                    UnitsInStock = 32,
                    LeaseCost = 0, // Niet van toepassing
                    InstallCost = 0, // Niet van toepassing
                    PricePerKilo = 27.80,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 10,
                    Name = "Kentucky Straight Single Origin",
                    ProductNumber = 23912348,
                    UnitsInStock = 46,
                    LeaseCost = 0, // Niet van toepassing
                    InstallCost = 0, // Niet van toepassing
                    PricePerKilo = 27.80,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 11,
                    Name = "Ipanema Beach Blonde Roast",
                    ProductNumber = 23912348,
                    UnitsInStock = 42,
                    LeaseCost = 0, // Niet van toepassing
                    InstallCost = 0, // Niet van toepassing
                    PricePerKilo = 27.80,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 12,
                    Name = "Cup'a'Joe Special",
                    ProductNumber = 23912348,
                    UnitsInStock = 13,
                    LeaseCost = 0, // Niet van toepassing
                    InstallCost = 0, // Niet van toepassing
                    PricePerKilo = 27.80,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 20,
                    Name = "Hot Beans! blend",
                    ProductNumber = 23912348,
                    UnitsInStock = 46,
                    LeaseCost = 0, // Niet van toepassing
                    InstallCost = 0, // Niet van toepassing
                    PricePerKilo = 27.80,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 21,
                    Name = "Black Cow blend",
                    ProductNumber = 23912348,
                    UnitsInStock = 42,
                    LeaseCost = 0, // Niet van toepassing
                    InstallCost = 0, // Niet van toepassing
                    PricePerKilo = 27.80,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 22,
                    Name = "Stawberry Fields Blend",
                    ProductNumber = 23912348,
                    UnitsInStock = 46,
                    LeaseCost = 0, // Niet van toepassing
                    InstallCost = 0, // Niet van toepassing
                    PricePerKilo = 27.80,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 23,
                    Name = "Samba Triste Blend",
                    ProductNumber = 23912348,
                    UnitsInStock = 42,
                    LeaseCost = 0, // Niet van toepassing
                    InstallCost = 0, // Niet van toepassing
                    PricePerKilo = 27.80,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 24,
                    Name = "Katy Lied Blend",
                    ProductNumber = 23912348,
                    UnitsInStock = 46,
                    LeaseCost = 0, // Niet van toepassing
                    InstallCost = 0, // Niet van toepassing
                    PricePerKilo = 27.80,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 25,
                    Name = "Aja Blend",
                    ProductNumber = 23912348,
                    UnitsInStock = 42,
                    LeaseCost = 0, // Niet van toepassing
                    InstallCost = 0, // Niet van toepassing
                    PricePerKilo = 27.80,
                    CategoryId = 2
                },
                new Product
                {
                Id = 100,
                Name = "Aja Brew Pro",
                ProductNumber = 10000001,
                LeaseCost = 599,
                InstallCost = 299,
                PricePerKilo = 0,
                CategoryId = 1,
                UnitsInStock = 120
                },
                new Product
                {
                    Id = 101,
                    Name = "Blackbird Roast",
                    ProductNumber = 10000002,
                    LeaseCost = 0,
                    InstallCost = 0,
                    PricePerKilo = 39,
                    CategoryId = 2,
                    UnitsInStock = 87
                },              
                new Product
                {
                    Id = 102,
                    Name = "Kind of Blue Espresso",
                    ProductNumber = 10000003,
                    LeaseCost = 0,
                    InstallCost = 0,
                    PricePerKilo = 45,
                    CategoryId = 2,
                    UnitsInStock = 102
                },
                new Product
                {
                    Id = 103,
                    Name = "Hey Brew-d Drip Machine",
                    ProductNumber = 10000004,
                    LeaseCost = 349,
                    InstallCost = 249,
                    PricePerKilo = 0,
                    CategoryId = 1,
                    UnitsInStock = 34
                },
                new Product
                {
                    Id = 104,
                    Name = "Deacon Blues Decaf Blend",
                    ProductNumber = 10000005,
                    LeaseCost = 0,
                    InstallCost = 0,
                    PricePerKilo = 42,
                    CategoryId = 2,
                    UnitsInStock = 56
                },
                new Product
                {
                    Id = 105,
                    Name = "Penny Lane Latte Blend",
                    ProductNumber = 10000006,
                    LeaseCost = 0,
                    InstallCost = 0,
                    PricePerKilo = 38,
                    CategoryId = 2,
                    UnitsInStock = 92
                },
                new Product
                {
                    Id = 106,
                    Name = "Round Midnight Blend (Decaf)",
                    ProductNumber = 10000007,
                    LeaseCost = 399,
                    InstallCost = 199,
                    PricePerKilo = 0,
                    CategoryId = 1,
                    UnitsInStock = 45
                },
                new Product
                {
                    Id = 3,
                    Name = "Eleanor Rig-Bean Blend",
                    ProductNumber = 10000008,
                    LeaseCost = 0,
                    InstallCost = 0,
                    PricePerKilo = 36,
                    CategoryId = 2,
                    UnitsInStock = 48
                },
                new Product
                {
                    Id = 108,
                    Name = "The Royal Scam 3000",
                    ProductNumber = 10000009,
                    LeaseCost = 259,
                    InstallCost = 139,
                    PricePerKilo = 0,
                    CategoryId = 1,
                    UnitsInStock = 48
                },
                new Product
                {
                    Id = 4,
                    Name = "Norwegian Wood Dark Roast",
                    ProductNumber = 10000010,
                    LeaseCost = 0,
                    InstallCost = 0,
                    PricePerKilo = 40,
                    CategoryId = 2,
                    UnitsInStock = 76
                },
                new Product
                {
                    Id = 110,
                    Name = "Birdland Brew System",
                    ProductNumber = 10000011,
                    LeaseCost = 499,
                    InstallCost = 299,
                    PricePerKilo = 0,
                    CategoryId = 1,
                    UnitsInStock = 53
                },
                new Product
                {
                    Id = 111,
                    Name = "Across the Universe Instant",
                    ProductNumber = 10000012,
                    LeaseCost = 269,
                    InstallCost = 159,
                    PricePerKilo = 0,
                    CategoryId = 1,
                    UnitsInStock = 29
                },
                new Product
                {
                    Id = 112,
                    Name = "Peg’s Perfect Roast",
                    ProductNumber = 10000013,
                    LeaseCost = 0,
                    InstallCost = 0,
                    PricePerKilo = 44,
                    CategoryId = 2,
                    UnitsInStock = 110
                },
                new Product
                {
                    Id = 113,
                    Name = "Something Latte Machine",
                    ProductNumber = 10000014,
                    LeaseCost = 549,
                    InstallCost = 349,
                    PricePerKilo = 0,
                    CategoryId = 1,
                    UnitsInStock = 36
                },
                new Product
                {
                    Id = 114,
                    Name = "Freddie Freeloader Blend",
                    ProductNumber = 10000015,
                    LeaseCost = 0,
                    InstallCost = 0,
                    PricePerKilo = 46,
                    CategoryId = 2,
                    UnitsInStock = 84
                },
                new Product
                {
                    Id = 5,
                    Name = "Abbey Roast",
                    ProductNumber = 10000016,
                    LeaseCost = 0,
                    InstallCost = 0,
                    PricePerKilo = 37,
                    CategoryId = 2,
                    UnitsInStock = 67
                },
                new Product
                {
                    Id = 116,
                    Name = "Blue Monk Brewing Kit",
                    ProductNumber = 10000017,
                    LeaseCost = 299,
                    InstallCost = 179,
                    PricePerKilo = 0,
                    CategoryId = 1,
                    UnitsInStock = 43
                },
                new Product
                {
                    Id = 117,
                    Name = "Golden Slumbers Blend",
                    ProductNumber = 10000018,
                    LeaseCost = 0,
                    InstallCost = 0,
                    PricePerKilo = 41,
                    CategoryId = 2,
                    UnitsInStock = 71
                },
                new Product
                {
                    Id = 6,
                    Name = "Rikki Don’t Lose That Grinder",
                    ProductNumber = 10000019,
                    LeaseCost = 279,
                    InstallCost = 159,
                    PricePerKilo = 0,
                    CategoryId = 1,
                    UnitsInStock = 38
                },
                new Product
                {
                    Id = 119,
                    Name = "Lazy Bird Espresso",
                    ProductNumber = 10000020,
                    LeaseCost = 0,
                    InstallCost = 0,
                    PricePerKilo = 43,
                    CategoryId = 2,
                    UnitsInStock = 66
                },
                new Product
                {
                    Id = 120,
                    Name = "Yesterday’s Brew Station",
                    ProductNumber = 10000021,
                    LeaseCost = 399,
                    InstallCost = 249,
                    PricePerKilo = 0,
                    CategoryId = 1,
                    UnitsInStock = 25
                },
                new Product
                {
                    Id = 121,
                    Name = "Haitian Divorce Roast",
                    ProductNumber = 10000022,
                    LeaseCost = 0,
                    InstallCost = 0,
                    PricePerKilo = 39,
                    CategoryId = 2,
                    UnitsInStock = 77
                },
                new Product
                {
                    Id = 122,
                    Name = "Someday My Brew Will Come",
                    ProductNumber = 10000023,
                    LeaseCost = 449,
                    InstallCost = 269,
                    PricePerKilo = 0,
                    CategoryId = 1,
                    UnitsInStock = 95
                },
                new Product
                {
                    Id = 123,
                    Name = "Day Dripper Drip Coffee",
                    ProductNumber = 10000024,
                    LeaseCost = 0,
                    InstallCost = 0,
                    PricePerKilo = 38,
                    CategoryId = 2,
                    UnitsInStock = 25
                },
                new Product
                {
                    Id = 124,
                    Name = "Black Coffee Monk Grinder",
                    ProductNumber = 10000025,
                    LeaseCost = 319,
                    InstallCost = 189,
                    PricePerKilo = 0,
                    CategoryId = 1,
                    UnitsInStock = 70
                },
                new Product
                {
                    Id = 125,
                    Name = "Michelle’s Morning Roast",
                    ProductNumber = 10000026,
                    LeaseCost = 0,
                    InstallCost = 0,
                    PricePerKilo = 42,
                    CategoryId = 2,
                    UnitsInStock = 74
                },
                new Product
                {
                    Id = 128,
                    Name = "Moanin’ Morning Brew Machine",
                    ProductNumber = 10000029,
                    LeaseCost = 499,
                    InstallCost = 299,
                    PricePerKilo = 0,
                    CategoryId = 1,
                    UnitsInStock = 63
                },
                new Product
                {
                    Id = 7,
                    Name = "Let It Bean",
                    ProductNumber = 10000030,
                    LeaseCost = 0,
                    InstallCost = 0,
                    PricePerKilo = 36,
                    CategoryId = 2,
                    UnitsInStock = 19
                }

            ]);
        appointments.AddRange([
            new Appointment
            {
                Id = 1,
                Date = DateTime.Now.AddDays(1),
                Duration = 60,
                Description = "Initial Consultation",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 1,
                Location = "Curio Terheijdenseweg 350 Breda"
            },
            new Appointment
            {
                Id = 2,
                Date = DateTime.Now.AddDays(2),
                Duration = 90,
                Description = "Follow-up",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 2,
                Location = "Curio Dr. Ir. van Veenweg 8 Bergen op Zoom"
            },
            new Appointment
            {
                Id = 3,
                Date = DateTime.Now.AddDays(2),
                Duration = 100,
                Description = "Follow-up",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 3,
                Location = "Curio Knipplein 10 Roosendaal"
            },
            new Appointment
            {
                Id = 4,
                Date = DateTime.Now.AddDays(1),
                Duration = 60,
                Description = "Lekkend Apparaat",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 1,
                Location = "CBS De Zevensprong Appelstraat 4 Krabbendijke"
            },
            new Appointment
            {
                Id = 5,
                Date = DateTime.Now.AddDays(2),
                Duration = 90,
                Description = "Follow-up",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 2,
                Location = "Ostrea Lyceum Fruitlaan 14 Goes"
            },
            new Appointment
            {
                Id = 6,
                Date = DateTime.Now.AddDays(2),
                Duration = 100,
                Description = "Follow-up",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 3,
                Location = "Theater De Mythe Gebr. De Wittlaan Middelburg"
            },
            new Appointment
            {
                Id = 7,
                Date = DateTime.Now.AddDays(2),
                Duration = 100,
                Description = "Follow-up",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 3,
                Location = "Goudgrijp Wegisweg 123 Londen"
            },
            new Appointment
            {
                Id = 8,
                Date = DateTime.Now.AddDays(2),
                Duration = 100,
                Description = "Follow-up",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 3,
                Location = "B. de Bouwer Aannemersbedrijf"
            },
            new Appointment
            {
                Id = 9,
                Date = DateTime.Now.AddDays(2),
                Duration = 100,
                Description = "Follow-up",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 3,
                Location = "Zwijnstein"
            },
            new Appointment
            {
                Id = 10,
                Date = DateTime.Now.AddDays(2),
                Duration = 100,
                Description = "Follow-up",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 3,
                Location = "Endor"
            },
            new Appointment
            {
                Id = 11,
                Date = DateTime.Now.AddDays(2),
                Duration = 100,
                Description = "Follow-up",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 3,
                Location = "Aldran"
            },
            new Appointment
            {
                Id = 12,
                Date = DateTime.Now.AddDays(2),
                Duration = 100,
                Description = "Follow-up",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 3,
                Location = "Kepler 22b"
            },
            new Appointment
            {
                Id = 13,
                Date = DateTime.Now.AddDays(2),
                Duration = 100,
                Description = "Follow-up",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 3,
                Location = "Abbey Road Studios, Londen, VK"
            },
            new Appointment
            {
                Id = 14,
                Date = DateTime.Now.AddDays(2),
                Duration = 100,
                Description = "Follow-up",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 3,
                Location = "VIM Agencies Camino la Sieniga, Los Angeles, USA"
            },
            new Appointment
            {
                Id = 15,
                Date = DateTime.Now.AddDays(2),
                Duration = 100,
                Description = "Follow-up",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 3,
                Location = "Peron 9 3/4"
            },
            new Appointment
            {
                Id = 16,
                Date = DateTime.Now.AddDays(2),
                Duration = 100,
                Description = "Follow-up",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 3,
                Location = "WhatTimeIsItRightnow.com HQ Los Angeles, USA"
            }

        ]);

        customers.AddRange([
            new Customer
            {
                Id = 1,
                CompanyName = "Tech Solutions Inc.",
                Address = "123 Tech Street, Innovation City",
                Description = "Leading provider of tech solutions."
            },
            new Customer
            {
                Id = 2,
                CompanyName = "Green Energy Co.",
                Address = "456 Renewable Lane, EcoTown",
                Description = "Specializes in renewable energy projects."
            }
        ]);

        contactPerson.AddRange([
            new CustomerContactPerson
            {
                Id = 1,
                CustomerId = 1
            },
            new CustomerContactPerson
            {
                Id = 2,
                CustomerId = 1
            }
        ]);
        // Seed data for users
        var users = new List<User>();
        users.AddRange([
            new User
            {
                Id = 101,
                Username = "ToddChavez", 
                Password = "ToddChavez",  
                RoleId = 8,
                Created_at = DateTime.Now,
                Role = null
            },
            new User
            {
                Id = 102,
                Username = "PrincesCarolin",
                Password = "PrincesCarolin",
                RoleId = 11, 
                Created_at = DateTime.Now,  
                Role = null
            }
        ]);

        var random = new Random();

        for (var i = 1; i <= 30; i++)
            users.Add(new User
            {
                Id = i,
                Username = $"User{i}",
                Password = SecureHasher.Hash("test"),
                RoleId = random.Next(3, 13),
                Created_at = DateTime.Now.AddDays(-random.Next(1, 1000)),
                Role = null
            });

        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<Category>().HasData(categories);
        modelBuilder.Entity<Product>().HasData(products);
        modelBuilder.Entity<Appointment>().HasData(appointments);

        modelBuilder.Entity<Customer>().HasData(customers);
        modelBuilder.Entity<CustomerContactPerson>().HasData(contactPerson);
    }
}