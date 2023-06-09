namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_MySkill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MySkills",
                c => new
                    {
                        MySkillID = c.Int(nullable: false, identity: true),
                        MySkillName = c.String(),
                        MySkillValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MySkillID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MySkills");
        }
    }
}
