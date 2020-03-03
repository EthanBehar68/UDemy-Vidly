namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelinquentAddedToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "delinquent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "delinquent");
        }
    }
}
