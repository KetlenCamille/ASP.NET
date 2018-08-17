namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTableItemVenda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemVendas",
                c => new
                    {
                        idItemVenda = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Preco = c.Double(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Produto_IdProduto = c.Int(),
                    })
                .PrimaryKey(t => t.idItemVenda)
                .ForeignKey("dbo.Produtos", t => t.Produto_IdProduto)
                .Index(t => t.Produto_IdProduto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemVendas", "Produto_IdProduto", "dbo.Produtos");
            DropIndex("dbo.ItemVendas", new[] { "Produto_IdProduto" });
            DropTable("dbo.ItemVendas");
        }
    }
}
