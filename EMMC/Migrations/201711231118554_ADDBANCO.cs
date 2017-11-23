namespace EMMC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDBANCO : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administradores",
                c => new
                    {
                        AdministradorId = c.Int(nullable: false, identity: true),
                        AdministradorCpf = c.String(),
                        AdministradorNome = c.String(),
                        AdministradorSenha = c.String(),
                    })
                .PrimaryKey(t => t.AdministradorId);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        CategoriaNome = c.String(),
                        CategoriaDescricao = c.String(),
                        AdministradorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.LoginAdministradores",
                c => new
                    {
                        LoginAdministradorId = c.Int(nullable: false, identity: true),
                        LoginAdministradorSessao = c.String(),
                        LoginAdministradorAdm_AdministradorId = c.Int(),
                    })
                .PrimaryKey(t => t.LoginAdministradorId)
                .ForeignKey("dbo.Administradores", t => t.LoginAdministradorAdm_AdministradorId)
                .Index(t => t.LoginAdministradorAdm_AdministradorId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        ProdutoNome = c.String(),
                        ProdutoDescricao = c.String(),
                        ProdutoQuantidade = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        AdministradorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.LoginAdministradores", "LoginAdministradorAdm_AdministradorId", "dbo.Administradores");
            DropIndex("dbo.Produtos", new[] { "CategoriaId" });
            DropIndex("dbo.LoginAdministradores", new[] { "LoginAdministradorAdm_AdministradorId" });
            DropTable("dbo.Produtos");
            DropTable("dbo.LoginAdministradores");
            DropTable("dbo.Categorias");
            DropTable("dbo.Administradores");
        }
    }
}
