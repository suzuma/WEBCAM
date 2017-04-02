namespace DEMOLO_DATOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INICIAL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        sNombre = c.String(nullable: false, unicode: false),
                        sApellido = c.String(nullable: false, unicode: false),
                        sImagen = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.EmpleadoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Empleados");
        }
    }
}
