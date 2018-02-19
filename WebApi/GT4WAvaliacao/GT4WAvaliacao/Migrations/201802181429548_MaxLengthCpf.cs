namespace GT4WAvaliacao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthCpf : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.cliente", new[] { "num_cpf" });
            AlterColumn("dbo.cliente", "num_cpf", c => c.String(maxLength: 14, unicode: false));
            CreateIndex("dbo.cliente", "num_cpf", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.cliente", new[] { "num_cpf" });
            AlterColumn("dbo.cliente", "num_cpf", c => c.String(maxLength: 11, unicode: false));
            CreateIndex("dbo.cliente", "num_cpf", unique: true);
        }
    }
}
