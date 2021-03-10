namespace tutorialspoint_test_API_framework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using tutorialspoint_test_API_framework.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<tutorialspoint_test_API_framework.Data.tutorialspoint_test_API_frameworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(tutorialspoint_test_API_framework.Data.tutorialspoint_test_API_frameworkContext context)
        {
            context.employees.AddOrUpdate(
                x => x.ID,
                new employee () { ID = 1, name = "chuck" },
                new employee () { ID = 2, name = "cassidy" },
                new employee () { ID = 3, name = "bob" },
                new employee () { ID = 4, name = "willis" },
                new employee () { ID = 5, name = "anadi" },
                new employee () { ID = 6, name = "arnab" },
                new employee () { ID = 7, name = "varun" },
                new employee () { ID = 8, name = "tom" },
                new employee () { ID = 9, name = "anand" },
                new employee () { ID = 10, name = "lenny" }
                );
            context.offices.AddOrUpdate(
                x => x.ID,
                new office ()
                {
                    ID = 101,
                    location = "holloway park",
                    employeeID = 1
                },
                new office()
                {
                    ID = 102,
                    location = "bristol park",
                    employeeID = 2
                },
                new office()
                {
                    ID = 103,
                    location = "newtown avenue",
                    employeeID = 3
                },
                new office()
                {
                    ID = 104,
                    location = "maldini square",
                    employeeID = 4
                },
                new office()
                {
                    ID = 105,
                    location = "middleway garden",
                    employeeID = 5
                },
                new office()
                {
                    ID = 106,
                    location = "baker street",
                    employeeID = 6
                },
                new office()
                {
                    ID = 107,
                    location = "lumbini pathway",
                    employeeID = 7
                },
                new office()
                {
                    ID = 108,
                    location = "toulouse guild",
                    employeeID = 8
                },
                new office()
                {
                    ID = 109,
                    location = "seventeen street",
                    employeeID = 9
                },
                new office()
                {
                    ID = 110,
                    location = "milk colony",
                    employeeID = 10
                }
                );
            context.updatedOffices.AddOrUpdate(
                x => x.ID,
                new updatedOffice()
                {
                    ID = 101,
                    location = "holloway park"
                },
                new updatedOffice()
                {
                    ID = 102,
                    location = "bristol park"
                },
                new updatedOffice()
                {
                    ID = 103,
                    location = "newtown avenue"
                },
                new updatedOffice()
                {
                    ID = 104,
                    location = "maldini square"
                },
                new updatedOffice()
                {
                    ID = 105,
                    location = "middleway garden"
                },
                new updatedOffice()
                {
                    ID = 106,
                    location = "baker street"
                },
                new updatedOffice()
                {
                    ID = 107,
                    location = "lumbini pathway"
                },
                new updatedOffice()
                {
                    ID = 108,
                    location = "toulouse guild"
                },
                new updatedOffice()
                {
                    ID = 109,
                    location = "seventeen street"
                },
                new updatedOffice()
                {
                    ID = 110,
                    location = "milk colony"
                }
                );
        }
    }
}
