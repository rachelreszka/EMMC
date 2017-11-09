namespace EMMC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBanco : DbMigration
    {
        public override void Up()
        {
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
                        ClienteCpf = c.String(nullable: false, maxLength: 128),
                        ClienteNome = c.String(),
                        ClienteEndereco = c.String(),
                        ClienteSenha = c.String(),
                    })
                .PrimaryKey(t => t.ClienteCpf);
            
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
            DropIndex("dbo.Produtos", new[] { "categoria_CategoriaId" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Clientes");
            DropTable("dbo.Categorias");
        }
    }
}
