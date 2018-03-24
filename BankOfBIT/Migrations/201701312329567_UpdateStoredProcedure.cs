namespace BankOfBIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStoredProcedure : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "ClientNumber", c => c.Long());
            AlterColumn("dbo.Transactions", "TransactionNumber", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "TransactionNumber", c => c.Long(nullable: false));
            AlterColumn("dbo.Clients", "ClientNumber", c => c.Long(nullable: false));
        }
    }
}
