namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class DelinquentAddedToCustomersCORRECTINGCasing : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Customers", "delinquent", "Delinquent");
        }

        public override void Down()
        {
            RenameColumn("dbo.Customers", "Delinquent", "delinquent");
        }
    }
}
