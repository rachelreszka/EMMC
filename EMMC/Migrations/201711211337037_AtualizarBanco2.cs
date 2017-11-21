namespace EMMC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizarBanco2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtos", "AdministradorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtos", "AdministradorId");
        }
    }
}
