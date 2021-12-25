namespace DoneMyHair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saloon : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Time = c.DateTime(nullable: false),
                        Content = c.String(),
                        SaloonID = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SaloonModels",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        SaloonName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(),
                        Description = c.String(),
                        SaloonOwnerID = c.String(),
                        SaloonAdress = c.String(),
                        Images = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SaloonModels");
            DropTable("dbo.Comments");
        }
    }
}
