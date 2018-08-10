namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriaTableProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtos", "Categoria_idCategoria", c => c.Int());
            CreateIndex("dbo.Produtos", "Categoria_idCategoria");
            AddForeignKey("dbo.Produtos", "Categoria_idCategoria", "dbo.Categorias", "idCategoria");
            DropColumn("dbo.Produtos", "Categoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtos", "Categoria", c => c.String());
            DropForeignKey("dbo.Produtos", "Categoria_idCategoria", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "Categoria_idCategoria" });
            DropColumn("dbo.Produtos", "Categoria_idCategoria");
        }
    }
}
