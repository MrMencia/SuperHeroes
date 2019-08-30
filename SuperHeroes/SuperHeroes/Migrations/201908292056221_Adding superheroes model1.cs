namespace SuperHeroes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingsuperheroesmodel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SuperHeroes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SuperHeroes", "Name", c => c.Int(nullable: false));
        }
    }
}
