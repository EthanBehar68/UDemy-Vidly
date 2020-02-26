namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviesAndCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId, BirthDate) VALUES ('John Smith', 0, 1, 1/1/1980)");
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId, BirthDate) VALUES ('Mary Williams', 1, 2, 1/1/1980)");

            Sql("INSERT INTO Movies ( Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Hangover', 1/1/2020, 12/12/2010, 5, 5)");
            Sql("INSERT INTO Movies ( Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Die Hard', 2/2/2019, 11/11/2011, 10, 1)");
            Sql("INSERT INTO Movies ( Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('The Terminator', 3/3/2018, 10/10/2012, 3, 2)");
            Sql("INSERT INTO Movies ( Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Toy Story', 4/4/2017, 09/09/2013, 15, 3)");
            Sql("INSERT INTO Movies ( Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Titanic', 5/5/2016, 08/08/2014, 1, 4)");

        }
        
        public override void Down()
        {
        }
    }
}
