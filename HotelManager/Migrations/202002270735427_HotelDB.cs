namespace HotelManagerReservationsPt3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HotelDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        IsAdult = c.Boolean(nullable: false),
                        ReservationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Reservations", t => t.ReservationID, cascadeDelete: true)
                .Index(t => t.ReservationID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoomID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        DeparatureDate = c.DateTime(nullable: false),
                        HasBreakfast = c.Boolean(nullable: false),
                        IsAllInclusive = c.Boolean(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.RoomID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Capacity = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        AdultPrice = c.Double(nullable: false),
                        KidPrice = c.Double(nullable: false),
                        Number = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EGN = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        FiredDate = c.DateTime(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "UserID", "dbo.Users");
            DropForeignKey("dbo.Reservations", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Clients", "ReservationID", "dbo.Reservations");
            DropIndex("dbo.Reservations", new[] { "UserID" });
            DropIndex("dbo.Reservations", new[] { "RoomID" });
            DropIndex("dbo.Clients", new[] { "ReservationID" });
            DropTable("dbo.Users");
            DropTable("dbo.Rooms");
            DropTable("dbo.Reservations");
            DropTable("dbo.Clients");
        }
    }
}
