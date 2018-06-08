namespace IncidentTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialIncidentNearMissDomainClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AffectedBodyParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Incidents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WhenIncidentOccurred = c.DateTime(nullable: false),
                        IncidentDescription = c.String(),
                        IncidentResponse = c.String(),
                        InitialRecommendations = c.String(),
                        AffectedBodyPart_Id = c.Int(),
                        Department_Id = c.Int(),
                        InjuryType_Id = c.Int(),
                        Location_Id = c.Int(),
                        ReportingEmployee_Id = c.String(maxLength: 128),
                        Witness_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AffectedBodyParts", t => t.AffectedBodyPart_Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .ForeignKey("dbo.InjuryTypes", t => t.InjuryType_Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ReportingEmployee_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Witness_Id)
                .Index(t => t.AffectedBodyPart_Id)
                .Index(t => t.Department_Id)
                .Index(t => t.InjuryType_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.ReportingEmployee_Id)
                .Index(t => t.Witness_Id);
            
            CreateTable(
                "dbo.InjuryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NearMisses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WhenNearMissOccurred = c.DateTime(nullable: false),
                        NearMissDescription = c.String(),
                        NearMissResponse = c.String(),
                        NearMissRecommendations = c.String(),
                        Department_Id = c.Int(),
                        Location_Id = c.Int(),
                        PotentialAffectedBodyPart_Id = c.Int(),
                        PotentialInjuryType_Id = c.Int(),
                        ReportingEmployee_Id = c.String(maxLength: 128),
                        Witness_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .ForeignKey("dbo.AffectedBodyParts", t => t.PotentialAffectedBodyPart_Id)
                .ForeignKey("dbo.InjuryTypes", t => t.PotentialInjuryType_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ReportingEmployee_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Witness_Id)
                .Index(t => t.Department_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.PotentialAffectedBodyPart_Id)
                .Index(t => t.PotentialInjuryType_Id)
                .Index(t => t.ReportingEmployee_Id)
                .Index(t => t.Witness_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NearMisses", "Witness_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.NearMisses", "ReportingEmployee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.NearMisses", "PotentialInjuryType_Id", "dbo.InjuryTypes");
            DropForeignKey("dbo.NearMisses", "PotentialAffectedBodyPart_Id", "dbo.AffectedBodyParts");
            DropForeignKey("dbo.NearMisses", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.NearMisses", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Incidents", "Witness_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Incidents", "ReportingEmployee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Incidents", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Incidents", "InjuryType_Id", "dbo.InjuryTypes");
            DropForeignKey("dbo.Incidents", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Incidents", "AffectedBodyPart_Id", "dbo.AffectedBodyParts");
            DropIndex("dbo.NearMisses", new[] { "Witness_Id" });
            DropIndex("dbo.NearMisses", new[] { "ReportingEmployee_Id" });
            DropIndex("dbo.NearMisses", new[] { "PotentialInjuryType_Id" });
            DropIndex("dbo.NearMisses", new[] { "PotentialAffectedBodyPart_Id" });
            DropIndex("dbo.NearMisses", new[] { "Location_Id" });
            DropIndex("dbo.NearMisses", new[] { "Department_Id" });
            DropIndex("dbo.Incidents", new[] { "Witness_Id" });
            DropIndex("dbo.Incidents", new[] { "ReportingEmployee_Id" });
            DropIndex("dbo.Incidents", new[] { "Location_Id" });
            DropIndex("dbo.Incidents", new[] { "InjuryType_Id" });
            DropIndex("dbo.Incidents", new[] { "Department_Id" });
            DropIndex("dbo.Incidents", new[] { "AffectedBodyPart_Id" });
            DropTable("dbo.NearMisses");
            DropTable("dbo.Locations");
            DropTable("dbo.InjuryTypes");
            DropTable("dbo.Incidents");
            DropTable("dbo.Departments");
            DropTable("dbo.AffectedBodyParts");
        }
    }
}
