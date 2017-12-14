namespace VirtualDeckStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StripeFinalized : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderedProducts", "CustomerIdentity", c => c.String());
            DropColumn("dbo.CustomerOrders", "FirstName");
            DropColumn("dbo.CustomerOrders", "LastName");
            DropColumn("dbo.CustomerOrders", "Address");
            DropColumn("dbo.CustomerOrders", "City");
            DropColumn("dbo.CustomerOrders", "State");
            DropColumn("dbo.CustomerOrders", "PostalCode");
            DropColumn("dbo.CustomerOrders", "Country");
            DropColumn("dbo.CustomerOrders", "Phone");
            DropColumn("dbo.CustomerOrders", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerOrders", "Email", c => c.String(nullable: false));
            AddColumn("dbo.CustomerOrders", "Phone", c => c.String(nullable: false, maxLength: 24));
            AddColumn("dbo.CustomerOrders", "Country", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.CustomerOrders", "PostalCode", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.CustomerOrders", "State", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.CustomerOrders", "City", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.CustomerOrders", "Address", c => c.String(nullable: false, maxLength: 70));
            AddColumn("dbo.CustomerOrders", "LastName", c => c.String(nullable: false, maxLength: 160));
            AddColumn("dbo.CustomerOrders", "FirstName", c => c.String(nullable: false, maxLength: 160));
            DropColumn("dbo.OrderedProducts", "CustomerIdentity");
        }
    }
}
