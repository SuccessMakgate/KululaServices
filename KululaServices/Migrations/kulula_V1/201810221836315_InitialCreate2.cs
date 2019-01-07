namespace KululaServices.Migrations.kulula_V1
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MemberPayments");
            AddPrimaryKey("dbo.MemberPayments", "TransactionDate");
            DropColumn("dbo.MemberPayments", "MemberPaymentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberPayments", "MemberPaymentId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.MemberPayments");
            AddPrimaryKey("dbo.MemberPayments", "MemberPaymentId");
        }
    }
}
