namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableProduto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        idCategoria = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.idCategoria);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Categorias");
        }
    }
}
