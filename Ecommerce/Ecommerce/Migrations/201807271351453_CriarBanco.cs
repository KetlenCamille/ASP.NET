namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        IdProduto = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Preco = c.Double(nullable: false),
                        Nome = c.String(),
                        Categoria = c.String(),
                        Imagem = c.String(),
                    })
                .PrimaryKey(t => t.IdProduto);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produtos");
        }
    }
}
