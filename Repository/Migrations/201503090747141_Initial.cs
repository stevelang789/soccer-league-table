namespace SteveLang.SoccerLeagueTable.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fixtures",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        HomeTeamScore = c.Int(nullable: false),
                        AwayTeamScore = c.Int(nullable: false),
                        AwayTeam_Id = c.Guid(),
                        HomeTeam_Id = c.Guid(),
                        League_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.AwayTeam_Id)
                .ForeignKey("dbo.Teams", t => t.HomeTeam_Id)
                .ForeignKey("dbo.Leagues", t => t.League_Id)
                .Index(t => t.AwayTeam_Id)
                .Index(t => t.HomeTeam_Id)
                .Index(t => t.League_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        League_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Leagues", t => t.League_Id)
                .Index(t => t.League_Id);
            
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Season = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fixtures", "League_Id", "dbo.Leagues");
            DropForeignKey("dbo.Fixtures", "HomeTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.Fixtures", "AwayTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.Teams", "League_Id", "dbo.Leagues");
            DropIndex("dbo.Teams", new[] { "League_Id" });
            DropIndex("dbo.Fixtures", new[] { "League_Id" });
            DropIndex("dbo.Fixtures", new[] { "HomeTeam_Id" });
            DropIndex("dbo.Fixtures", new[] { "AwayTeam_Id" });
            DropTable("dbo.Leagues");
            DropTable("dbo.Teams");
            DropTable("dbo.Fixtures");
        }
    }
}
