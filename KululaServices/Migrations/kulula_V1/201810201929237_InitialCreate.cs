namespace KululaServices.Migrations.kulula_V1
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aircraft",
                c => new
                    {
                        AircraftId = c.Int(nullable: false, identity: true),
                        AircraftNo = c.String(),
                        AircraftName = c.String(),
                        MaxSeats = c.Int(nullable: false),
                        NumSeatBooked = c.Int(nullable: false),
                        AircraftLogo = c.String(),
                        IsFlightFull = c.Boolean(nullable: false),
                        price = c.Int(nullable: false),
                        FlightSchedule_FlightScheduleId = c.Int(),
                    })
                .PrimaryKey(t => t.AircraftId)
                .ForeignKey("dbo.FlightSchedules", t => t.FlightSchedule_FlightScheduleId)
                .Index(t => t.FlightSchedule_FlightScheduleId);
            
            CreateTable(
                "dbo.Carhires",
                c => new
                    {
                        carHireId = c.Int(nullable: false, identity: true),
                        pickUp = c.String(),
                        DropOff = c.String(),
                        IsReturn = c.Boolean(nullable: false),
                        PickDate = c.DateTime(nullable: false),
                        PaymentStatus = c.Boolean(nullable: false),
                        CarName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.carHireId)
                .ForeignKey("dbo.CarModels", t => t.CarName)
                .Index(t => t.CarName);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        CarName = c.String(nullable: false, maxLength: 128),
                        CarColour = c.String(),
                        YearModel = c.String(),
                        LeatherSeat = c.Boolean(nullable: false),
                        Radio_Cd = c.Boolean(nullable: false),
                        AirBag = c.Boolean(nullable: false),
                        price = c.Int(nullable: false),
                        carImage = c.String(),
                    })
                .PrimaryKey(t => t.CarName);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        IdNumber = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        PhoneNo = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.MemberPayments",
                c => new
                    {
                        MemberPaymentId = c.Int(nullable: false, identity: true),
                        PaymentId = c.Int(nullable: false),
                        Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MemberPaymentId)
                .ForeignKey("dbo.Clients", t => t.Email)
                .Index(t => t.Email);
            
            CreateTable(
                "dbo.FlightBooks",
                c => new
                    {
                        FlightBookId = c.Int(nullable: false, identity: true),
                        DestPlace = c.String(),
                        DepartPlace = c.String(),
                        DepartDate = c.DateTime(nullable: false),
                        returnDate = c.DateTime(nullable: false),
                        IsReturn = c.Boolean(nullable: false),
                        NumPeople = c.Int(nullable: false),
                        FlightScheduleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FlightBookId);
            
            CreateTable(
                "dbo.FlightSchedules",
                c => new
                    {
                        FlightScheduleId = c.Int(nullable: false, identity: true),
                        DepartDate = c.DateTime(nullable: false),
                        DepartTime = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        ReturnTime = c.DateTime(nullable: false),
                        FlightBook_FlightBookId = c.Int(),
                    })
                .PrimaryKey(t => t.FlightScheduleId)
                .ForeignKey("dbo.FlightBooks", t => t.FlightBook_FlightBookId)
                .Index(t => t.FlightBook_FlightBookId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        payMethod = c.String(),
                        AccHolder = c.String(),
                        AccountNo = c.String(),
                        CardNo = c.String(),
                        TransactionDate = c.DateTime(nullable: false),
                        IsCarhire = c.Boolean(nullable: false),
                        IsSeatBook = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            CreateTable(
                "dbo.SeatBookings",
                c => new
                    {
                        SeatBookingId = c.Int(nullable: false, identity: true),
                        SeatNumber = c.Int(nullable: false),
                        SeatPrice = c.Int(nullable: false),
                        SeatName = c.String(),
                        PaymentStatus = c.Boolean(nullable: false),
                        AircraftId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeatBookingId)
                .ForeignKey("dbo.Aircraft", t => t.AircraftId, cascadeDelete: true)
                .Index(t => t.AircraftId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeatBookings", "AircraftId", "dbo.Aircraft");
            DropForeignKey("dbo.FlightSchedules", "FlightBook_FlightBookId", "dbo.FlightBooks");
            DropForeignKey("dbo.Aircraft", "FlightSchedule_FlightScheduleId", "dbo.FlightSchedules");
            DropForeignKey("dbo.MemberPayments", "Email", "dbo.Clients");
            DropForeignKey("dbo.Carhires", "CarName", "dbo.CarModels");
            DropIndex("dbo.SeatBookings", new[] { "AircraftId" });
            DropIndex("dbo.FlightSchedules", new[] { "FlightBook_FlightBookId" });
            DropIndex("dbo.MemberPayments", new[] { "Email" });
            DropIndex("dbo.Carhires", new[] { "CarName" });
            DropIndex("dbo.Aircraft", new[] { "FlightSchedule_FlightScheduleId" });
            DropTable("dbo.SeatBookings");
            DropTable("dbo.Payments");
            DropTable("dbo.FlightSchedules");
            DropTable("dbo.FlightBooks");
            DropTable("dbo.MemberPayments");
            DropTable("dbo.Clients");
            DropTable("dbo.CarModels");
            DropTable("dbo.Carhires");
            DropTable("dbo.Aircraft");
        }
    }
}
