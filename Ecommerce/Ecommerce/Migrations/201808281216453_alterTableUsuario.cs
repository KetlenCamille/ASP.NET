namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterTableUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Endereco", c => c.String());
            AddColumn("dbo.Usuarios", "Telefone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Telefone");
            DropColumn("dbo.Usuarios", "Endereco");
        }
    }
}
