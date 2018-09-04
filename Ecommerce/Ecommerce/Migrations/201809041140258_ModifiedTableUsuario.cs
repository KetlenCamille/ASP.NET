namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedTableUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemVendas", "Venda_idVenda", c => c.Int());
            AlterColumn("dbo.Usuarios", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "Senha", c => c.String(nullable: false));
            CreateIndex("dbo.ItemVendas", "Venda_idVenda");
            AddForeignKey("dbo.ItemVendas", "Venda_idVenda", "dbo.Vendas", "idVenda");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemVendas", "Venda_idVenda", "dbo.Vendas");
            DropIndex("dbo.ItemVendas", new[] { "Venda_idVenda" });
            AlterColumn("dbo.Usuarios", "Senha", c => c.String());
            AlterColumn("dbo.Usuarios", "Email", c => c.String());
            AlterColumn("dbo.Usuarios", "Nome", c => c.String());
            DropColumn("dbo.ItemVendas", "Venda_idVenda");
        }
    }
}
