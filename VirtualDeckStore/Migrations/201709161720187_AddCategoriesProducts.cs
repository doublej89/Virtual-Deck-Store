namespace VirtualDeckStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesProducts : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Categories ON");
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Dairy')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'Meats')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (3, 'Bakery')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (4, 'Fruits')");

            Sql("INSERT INTO Products (Name, Price, Description, LastUpdated, CategoryId) VALUES ('Cheese', 11.2, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', GETDATE(), 1)");
            Sql("INSERT INTO Products (Name, Price, Description, LastUpdated, CategoryId) VALUES ('Butter', 5.4, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', GETDATE(), 1)");
            Sql("INSERT INTO Products (Name, Price, Description, LastUpdated, CategoryId) VALUES ('Chicken leg', 50.3, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', GETDATE(), 2)");
        }
        
        public override void Down()
        {
        }
    }
}
