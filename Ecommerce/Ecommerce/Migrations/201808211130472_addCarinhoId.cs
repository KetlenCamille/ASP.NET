namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCarinhoId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemVendas", "CarrinhoId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemVendas", "CarrinhoId");
        }
    }
}
