namespace VirtualDeckStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletingData : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Products");
            Sql("DELETE FROM Categories");
        }
        
        public override void Down()
        {
        }
    }
}
