namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviesDataAdded : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES (1, 'Hangover', 1, 2013-10-21 12:30:00, GetUTCDate(), 8)");
            //Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES (2, 'Die Hard', 2, 2014-10-21 10:20:00, GetUTCDate(), 6)");
            //Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES (3, 'The Terminator', 2, 1999-10-21 02:10:00, GetUTCDate(), 2)");
            //Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES (4, 'Toy Story', 3, 2000-10-21 01:40:00, GetUTCDate(), 3)");
            //Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES (5, 'Titanic', 4,  2001-10-21 05:45:00, GetUTCDate(), 4)");
        }
        
        public override void Down()
        {
        }
    }
}
