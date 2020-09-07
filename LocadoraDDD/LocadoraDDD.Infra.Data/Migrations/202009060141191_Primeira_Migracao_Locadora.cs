//namespace LocadoraDDD.Infra.Data.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class Primeira_Migracao_Locadora : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.Filme",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        Nome = c.String(),
//                        DataCriacao = c.DateTime(nullable: false),
//                        GeneroId = c.Int(nullable: false),
//                        Ativo = c.Boolean(nullable: false),
//                        Locacao_Id = c.Int(),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Genero", t => t.GeneroId)
//                .ForeignKey("dbo.Locacao", t => t.Locacao_Id)
//                .Index(t => t.GeneroId)
//                .Index(t => t.Locacao_Id);
            
//            CreateTable(
//                "dbo.Genero",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        Nome = c.String(),
//                        DataCriacao = c.DateTime(nullable: false),
//                        Ativo = c.Boolean(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id);
            
//            CreateTable(
//                "dbo.Locacao",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        CpfCliente = c.String(),
//                        DataLocacao = c.DateTime(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id);
            
//            CreateTable(
//                "dbo.AspNetRoles",
//                c => new
//                    {
//                        Id = c.String(nullable: false, maxLength: 128),
//                        Name = c.String(nullable: false, maxLength: 256),
//                    })
//                .PrimaryKey(t => t.Id)
//                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
//            CreateTable(
//                "dbo.AspNetUserRoles",
//                c => new
//                    {
//                        UserId = c.String(nullable: false, maxLength: 128),
//                        RoleId = c.String(nullable: false, maxLength: 128),
//                    })
//                .PrimaryKey(t => new { t.UserId, t.RoleId })
//                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
//                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
//                .Index(t => t.UserId)
//                .Index(t => t.RoleId);
            
//            CreateTable(
//                "dbo.AspNetUsers",
//                c => new
//                    {
//                        Id = c.String(nullable: false, maxLength: 128),
//                        Nome = c.String(),
//                        Cpf = c.String(),
//                        Email = c.String(maxLength: 256),
//                        EmailConfirmed = c.Boolean(nullable: false),
//                        PasswordHash = c.String(),
//                        SecurityStamp = c.String(),
//                        PhoneNumber = c.String(),
//                        PhoneNumberConfirmed = c.Boolean(nullable: false),
//                        TwoFactorEnabled = c.Boolean(nullable: false),
//                        LockoutEndDateUtc = c.DateTime(),
//                        LockoutEnabled = c.Boolean(nullable: false),
//                        AccessFailedCount = c.Int(nullable: false),
//                        UserName = c.String(nullable: false, maxLength: 256),
//                    })
//                .PrimaryKey(t => t.Id)
//                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
//            CreateTable(
//                "dbo.AspNetUserClaims",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        UserId = c.String(nullable: false, maxLength: 128),
//                        ClaimType = c.String(),
//                        ClaimValue = c.String(),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
//                .Index(t => t.UserId);
            
//            CreateTable(
//                "dbo.AspNetUserLogins",
//                c => new
//                    {
//                        LoginProvider = c.String(nullable: false, maxLength: 128),
//                        ProviderKey = c.String(nullable: false, maxLength: 128),
//                        UserId = c.String(nullable: false, maxLength: 128),
//                    })
//                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
//                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
//                .Index(t => t.UserId);
            
//        }
        
//        public override void Down()
//        {
//            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
//            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
//            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
//            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
//            DropForeignKey("dbo.Filme", "Locacao_Id", "dbo.Locacao");
//            DropForeignKey("dbo.Filme", "GeneroId", "dbo.Genero");
//            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
//            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
//            DropIndex("dbo.AspNetUsers", "UserNameIndex");
//            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
//            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
//            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
//            DropIndex("dbo.Filme", new[] { "Locacao_Id" });
//            DropIndex("dbo.Filme", new[] { "GeneroId" });
//            DropTable("dbo.AspNetUserLogins");
//            DropTable("dbo.AspNetUserClaims");
//            DropTable("dbo.AspNetUsers");
//            DropTable("dbo.AspNetUserRoles");
//            DropTable("dbo.AspNetRoles");
//            DropTable("dbo.Locacao");
//            DropTable("dbo.Genero");
//            DropTable("dbo.Filme");
//        }
//    }
//}
