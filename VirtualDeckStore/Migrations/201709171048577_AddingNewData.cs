namespace VirtualDeckStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNewData : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Categories ON");
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Adventure')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'Racing')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (3, 'RolePlaying')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (4, 'Strategy')");

            Sql("INSERT INTO Products (Name, Price, Description, LastUpdated, CategoryId) VALUES ('Syberia', 11.2, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', GETDATE(), 1)");
            Sql("INSERT INTO Products (Name, Price, Description, LastUpdated, CategoryId) VALUES ('The Last Express', 5.4, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', GETDATE(), 1)");
            Sql("INSERT INTO Products (Name, Price, Description, LastUpdated, CategoryId) VALUES ('Dirt Rally', 50.3, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', GETDATE(), 2)");
            Sql("INSERT INTO Products (Name, Price, Description, LastUpdated, CategoryId) VALUES ('Gran Turismo Sport', 50.3, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', GETDATE(), 2)");
            Sql("INSERT INTO Products (Name, Price, Description, LastUpdated, CategoryId) VALUES ('Dark Souls', 50.3, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', GETDATE(), 3)");
            Sql("INSERT INTO Products (Name, Price, Description, LastUpdated, CategoryId) VALUES ('Witcher 3', 50.3, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', GETDATE(), 3)");
            Sql("INSERT INTO Products (Name, Price, Description, LastUpdated, CategoryId) VALUES ('Civilization VI', 50.3, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', GETDATE(), 4)");
            Sql("INSERT INTO Products (Name, Price, Description, LastUpdated, CategoryId) VALUES ('Starcraft II', 50.3, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', GETDATE(), 4)");
        }
        
        public override void Down()
        {
        }
    }
}
