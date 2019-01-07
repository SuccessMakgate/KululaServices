namespace KululaServices.Migrations.kulula_V1
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberPayments", "discount", c => c.Double(nullable: false));
            AddColumn("dbo.MemberPayments", "kululaPoints", c => c.Int(nullable: false));
            AddColumn("dbo.MemberPayments", "TransactionDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MemberPayments", "TransactionDate");
            DropColumn("dbo.MemberPayments", "kululaPoints");
            DropColumn("dbo.MemberPayments", "discount");
        }
    }
}
