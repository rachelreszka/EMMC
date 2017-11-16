namespace EMMC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBanco : DbMigration
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
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        ClienteCpf = c.String(),
                        ClienteNome = c.String(),
                        ClienteEndereco = c.String(),
                        ClienteSenha = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
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
                "dbo.LoginClientes",
                c => new
                    {
                        LoginClienteId = c.Int(nullable: false, identity: true),
                        LoginClienteSessao = c.String(),
                        LoginClienteCli_ClienteId = c.Int(),
                    })
                .PrimaryKey(t => t.LoginClienteId)
                .ForeignKey("dbo.Clientes", t => t.LoginClienteCli_ClienteId)
                .Index(t => t.LoginClienteCli_ClienteId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        ProdutoNome = c.String(),
                        ProdutoDescricao = c.String(),
                        ProdutoQuantidade = c.Int(nullable: false),
                        categoria_CategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categorias", t => t.categoria_CategoriaId)
                .Index(t => t.categoria_CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "categoria_CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.LoginClientes", "LoginClienteCli_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.LoginAdministradores", "LoginAdministradorAdm_AdministradorId", "dbo.Administradores");
            DropIndex("dbo.Produtos", new[] { "categoria_CategoriaId" });
            DropIndex("dbo.LoginClientes", new[] { "LoginClienteCli_ClienteId" });
            DropIndex("dbo.LoginAdministradores", new[] { "LoginAdministradorAdm_AdministradorId" });
            DropTable("dbo.Produtos");
            DropTable("dbo.LoginClientes");
            DropTable("dbo.LoginAdministradores");
            DropTable("dbo.Clientes");
            DropTable("dbo.Categorias");
            DropTable("dbo.Administradores");
        }
    }
}
