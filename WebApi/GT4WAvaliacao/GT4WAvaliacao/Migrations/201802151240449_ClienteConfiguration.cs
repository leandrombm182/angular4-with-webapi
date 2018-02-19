namespace GT4WAvaliacao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClienteConfiguration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cliente",
                c => new
                    {
                        cod_cliente = c.Int(nullable: false, identity: true),
                        nome_cliente = c.String(maxLength: 100, unicode: false),
                        num_cpf = c.String(maxLength: 14, unicode: false),
                        dat_nascimento = c.DateTime(nullable: false, storeType: "date"),
                        peso = c.Single(nullable: false),
                        Estado = c.String(maxLength: 2, unicode: false),
                    })
                .PrimaryKey(t => t.cod_cliente)
                .Index(t => t.num_cpf, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.cliente", new[] { "num_cpf" });
            DropTable("dbo.cliente");
        }
    }
}
