namespace BankOfBIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewNavigationalProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        TransactionNumber = c.Long(nullable: false),
                        BankAccountId = c.Int(nullable: false),
                        TransactionTypeId = c.Int(nullable: false),
                        Deposit = c.Double(nullable: false),
                        Withdrawal = c.Double(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.TransactionTypes", t => t.TransactionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccountId, cascadeDelete: true)
                .Index(t => t.TransactionTypeId)
                .Index(t => t.BankAccountId);
            
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        TransactionTypeId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ServiceCharges = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionTypeId);
            
            CreateTable(
                "dbo.NextClientNumbers",
                c => new
                    {
                        NextClientNumberId = c.Int(nullable: false, identity: true),
                        NextAvailableNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.NextClientNumberId);
            
            CreateTable(
                "dbo.NextSavingsAccounts",
                c => new
                    {
                        NextSavingsAccountId = c.Int(nullable: false, identity: true),
                        NextAvailableNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.NextSavingsAccountId);
            
            CreateTable(
                "dbo.NextMortgageAccounts",
                c => new
                    {
                        NextMortgageAccountId = c.Int(nullable: false, identity: true),
                        NextAvailableNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.NextMortgageAccountId);
            
            CreateTable(
                "dbo.NextInvestmentAccounts",
                c => new
                    {
                        NextInvestmentAccountId = c.Int(nullable: false, identity: true),
                        NextAvailableNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.NextInvestmentAccountId);
            
            CreateTable(
                "dbo.NextChequingAccounts",
                c => new
                    {
                        NextChequingAccountId = c.Int(nullable: false, identity: true),
                        NextAvailableNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.NextChequingAccountId);
            
            CreateTable(
                "dbo.NextTransactionNumbers",
                c => new
                    {
                        NextTransactionNumberId = c.Int(nullable: false, identity: true),
                        NextAvailableNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.NextTransactionNumberId);
            
            CreateTable(
                "dbo.Payees",
                c => new
                    {
                        PayeeId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PayeeId);
            
            CreateTable(
                "dbo.Institutions",
                c => new
                    {
                        InstitutionId = c.Int(nullable: false, identity: true),
                        InstituionNumber = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.InstitutionId);
            
            CreateTable(
                "dbo.RFIDTags",
                c => new
                    {
                        RFIDTagId = c.Int(nullable: false, identity: true),
                        CardNumber = c.Long(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RFIDTagId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.RFIDTags", new[] { "ClientId" });
            DropIndex("dbo.Transactions", new[] { "BankAccountId" });
            DropIndex("dbo.Transactions", new[] { "TransactionTypeId" });
            DropForeignKey("dbo.RFIDTags", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Transactions", "BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.Transactions", "TransactionTypeId", "dbo.TransactionTypes");
            DropTable("dbo.RFIDTags");
            DropTable("dbo.Institutions");
            DropTable("dbo.Payees");
            DropTable("dbo.NextTransactionNumbers");
            DropTable("dbo.NextChequingAccounts");
            DropTable("dbo.NextInvestmentAccounts");
            DropTable("dbo.NextMortgageAccounts");
            DropTable("dbo.NextSavingsAccounts");
            DropTable("dbo.NextClientNumbers");
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.Transactions");
        }
    }
}
