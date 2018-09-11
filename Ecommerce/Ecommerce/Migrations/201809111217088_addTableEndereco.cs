namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableEndereco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        idEndereco = c.Int(nullable: false, identity: true),
                        CEP = c.String(),
                        Logradouro = c.String(),
                        Bairro = c.String(),
                        Localidade = c.String(),
                        UF = c.String(),
                    })
                .PrimaryKey(t => t.idEndereco);
            
            AddColumn("dbo.Usuarios", "Endereco_idEndereco", c => c.Int());
            CreateIndex("dbo.Usuarios", "Endereco_idEndereco");
            AddForeignKey("dbo.Usuarios", "Endereco_idEndereco", "dbo.Enderecoes", "idEndereco");
            DropColumn("dbo.Usuarios", "Endereco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Endereco", c => c.String());
            DropForeignKey("dbo.Usuarios", "Endereco_idEndereco", "dbo.Enderecoes");
            DropIndex("dbo.Usuarios", new[] { "Endereco_idEndereco" });
            DropColumn("dbo.Usuarios", "Endereco_idEndereco");
            DropTable("dbo.Enderecoes");
        }
    }
}
