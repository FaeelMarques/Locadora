//namespace LocadoraDDD.Infra.Data.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class Ajuste_Relacionamento_Locacao_e_Filme : DbMigration
//    {
//        public override void Up()
//        {
//            DropForeignKey("dbo.Filme", "Locacao_Id", "dbo.Locacao");
//            DropIndex("dbo.Filme", new[] { "Locacao_Id" });
//            CreateTable(
//                "dbo.LocacaoFilmes",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        FilmeId = c.Int(nullable: false),
//                        LocacaoId = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Filme", t => t.FilmeId)
//                .ForeignKey("dbo.Locacao", t => t.LocacaoId)
//                .Index(t => t.FilmeId)
//                .Index(t => t.LocacaoId);
            
//            DropColumn("dbo.Filme", "Locacao_Id");
//        }
        
//        public override void Down()
//        {
//            AddColumn("dbo.Filme", "Locacao_Id", c => c.Int());
//            DropForeignKey("dbo.LocacaoFilmes", "LocacaoId", "dbo.Locacao");
//            DropForeignKey("dbo.LocacaoFilmes", "FilmeId", "dbo.Filme");
//            DropIndex("dbo.LocacaoFilmes", new[] { "LocacaoId" });
//            DropIndex("dbo.LocacaoFilmes", new[] { "FilmeId" });
//            DropTable("dbo.LocacaoFilmes");
//            CreateIndex("dbo.Filme", "Locacao_Id");
//            AddForeignKey("dbo.Filme", "Locacao_Id", "dbo.Locacao", "Id");
//        }
//    }
//}
