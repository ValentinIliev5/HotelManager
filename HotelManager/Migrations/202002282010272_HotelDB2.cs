namespace HotelManagerReservationsPt3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HotelDB2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "ReservationID", "dbo.Reservations");
            DropIndex("dbo.Clients", new[] { "ReservationID" });
            CreateTable(
                "dbo.ReservationClients",
                c => new
                    {
                        Reservation_ID = c.Int(nullable: false),
                        Client_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reservation_ID, t.Client_ID })
                .ForeignKey("dbo.Reservations", t => t.Reservation_ID, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_ID, cascadeDelete: true)
                .Index(t => t.Reservation_ID)
                .Index(t => t.Client_ID);
            
            DropColumn("dbo.Clients", "ReservationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "ReservationID", c => c.Int(nullable: false));
            DropForeignKey("dbo.ReservationClients", "Client_ID", "dbo.Clients");
            DropForeignKey("dbo.ReservationClients", "Reservation_ID", "dbo.Reservations");
            DropIndex("dbo.ReservationClients", new[] { "Client_ID" });
            DropIndex("dbo.ReservationClients", new[] { "Reservation_ID" });
            DropTable("dbo.ReservationClients");
            CreateIndex("dbo.Clients", "ReservationID");
            AddForeignKey("dbo.Clients", "ReservationID", "dbo.Reservations", "ID", cascadeDelete: true);
        }
    }
}
