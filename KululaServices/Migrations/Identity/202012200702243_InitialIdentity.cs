namespace KululaServices.Migrations.Identity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialIdentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KululaRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.KululaUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.KululaRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.KululaUser", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.KululaUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        ActivationCode = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.KululaUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KululaUser", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.KululaUserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.KululaUser", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KululaUserRoles", "IdentityUser_Id", "dbo.KululaUser");
            DropForeignKey("dbo.KululaUserLogin", "IdentityUser_Id", "dbo.KululaUser");
            DropForeignKey("dbo.KululaUserClaim", "IdentityUser_Id", "dbo.KululaUser");
            DropForeignKey("dbo.KululaUserRoles", "RoleId", "dbo.KululaRoles");
            DropIndex("dbo.KululaUserLogin", new[] { "IdentityUser_Id" });
            DropIndex("dbo.KululaUserClaim", new[] { "IdentityUser_Id" });
            DropIndex("dbo.KululaUser", "UserNameIndex");
            DropIndex("dbo.KululaUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.KululaUserRoles", new[] { "RoleId" });
            DropIndex("dbo.KululaRoles", "RoleNameIndex");
            DropTable("dbo.KululaUserLogin");
            DropTable("dbo.KululaUserClaim");
            DropTable("dbo.KululaUser");
            DropTable("dbo.KululaUserRoles");
            DropTable("dbo.KululaRoles");
        }
    }
}
