namespace BioscoopSysteemWebsite.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DirectorID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        EnglishDescription = c.String(),
                        ImageData = c.String(),
                        BannerImage = c.String(),
                        Language = c.String(),
                        Subtitle = c.String(),
                        Duration = c.Int(nullable: false),
                        Type = c.Boolean(nullable: false),
                        Genre = c.String(),
                        TrailerUrl = c.String(),
                        IMDBUrl = c.String(),
                        FilmWebsite = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Director_DirectorID = c.Int(),
                        Pegi_PegiId = c.Int(),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.Directors", t => t.Director_DirectorID)
                .ForeignKey("dbo.Pegis", t => t.Pegi_PegiId)
                .Index(t => t.Director_DirectorID)
                .Index(t => t.Pegi_PegiId);
            
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ActorId);
            
            CreateTable(
                "dbo.Pegis",
                c => new
                    {
                        PegiId = c.Int(nullable: false, identity: true),
                        All = c.Boolean(nullable: false),
                        SixPlus = c.Boolean(nullable: false),
                        TwelvePlus = c.Boolean(nullable: false),
                        SixteenPlus = c.Boolean(nullable: false),
                        Violence = c.Boolean(nullable: false),
                        Horror = c.Boolean(nullable: false),
                        Sex = c.Boolean(nullable: false),
                        Language = c.Boolean(nullable: false),
                        Drugs = c.Boolean(nullable: false),
                        Racism = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PegiId);
            
            CreateTable(
                "dbo.Mails",
                c => new
                    {
                        MailId = c.Int(nullable: false, identity: true),
                        MailAdres = c.String(),
                    })
                .PrimaryKey(t => t.MailId);
            
            CreateTable(
                "dbo.LadiesNights",
                c => new
                    {
                        LadiesNightid = c.Int(nullable: false, identity: true),
                        LadiesNightDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LadiesNightid);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Paid = c.Boolean(nullable: false),
                        PickedUp = c.Boolean(nullable: false),
                        Email = c.String(nullable: false),
                        ShowID = c.Int(nullable: false),
                        SecretShowOrder = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Shows", t => t.ShowID, cascadeDelete: true)
                .Index(t => t.ShowID);
            
            CreateTable(
                "dbo.Shows",
                c => new
                    {
                        ShowID = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        PopcornArrangement = c.Boolean(nullable: false),
                        MovieId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        LadiesNightid = c.Int(),
                        Holiday = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ShowID)
                .ForeignKey("dbo.LadiesNights", t => t.LadiesNightid)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.RoomId)
                .Index(t => t.LadiesNightid);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatId = c.Int(nullable: false, identity: true),
                        Row = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        ShowID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeatId)
                .ForeignKey("dbo.Shows", t => t.ShowID, cascadeDelete: true)
                .Index(t => t.ShowID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomNumber = c.Int(nullable: false),
                        Accessibility = c.Boolean(nullable: false),
                        Type = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.RoomRows",
                c => new
                    {
                        RoomRowID = c.Int(nullable: false, identity: true),
                        RowNumber = c.Int(nullable: false),
                        SeatAmount = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomRowID)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        SeatId = c.Int(),
                        TicketSoortID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Seats", t => t.SeatId)
                .ForeignKey("dbo.TicketSoorts", t => t.TicketSoortID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.SeatId)
                .Index(t => t.TicketSoortID);
            
            CreateTable(
                "dbo.TicketSoorts",
                c => new
                    {
                        TicketSoortID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        EnglishTicketName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TicketSoortID);
            
            CreateTable(
                "dbo.BackofficeRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.BackofficeUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.BackofficeRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.BackofficeUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.BackofficeUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Tussenvoegsel = c.String(),
                        BackofficeUsertypeId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        type_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BackofficeRoles", t => t.type_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.type_Id);
            
            CreateTable(
                "dbo.BackofficeUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BackofficeUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BackofficeUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.BackofficeUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ActorMovies",
                c => new
                    {
                        Actor_ActorId = c.Int(nullable: false),
                        Movie_MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Actor_ActorId, t.Movie_MovieId })
                .ForeignKey("dbo.Actors", t => t.Actor_ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId, cascadeDelete: true)
                .Index(t => t.Actor_ActorId)
                .Index(t => t.Movie_MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BackofficeUsers", "type_Id", "dbo.BackofficeRoles");
            DropForeignKey("dbo.BackofficeUserRoles", "UserId", "dbo.BackofficeUsers");
            DropForeignKey("dbo.BackofficeUserLogins", "UserId", "dbo.BackofficeUsers");
            DropForeignKey("dbo.BackofficeUserClaims", "UserId", "dbo.BackofficeUsers");
            DropForeignKey("dbo.BackofficeUserRoles", "RoleId", "dbo.BackofficeRoles");
            DropForeignKey("dbo.Tickets", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Tickets", "TicketSoortID", "dbo.TicketSoorts");
            DropForeignKey("dbo.Tickets", "SeatId", "dbo.Seats");
            DropForeignKey("dbo.Orders", "ShowID", "dbo.Shows");
            DropForeignKey("dbo.Shows", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomRows", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Shows", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Shows", "LadiesNightid", "dbo.LadiesNights");
            DropForeignKey("dbo.Seats", "ShowID", "dbo.Shows");
            DropForeignKey("dbo.Movies", "Pegi_PegiId", "dbo.Pegis");
            DropForeignKey("dbo.Movies", "Director_DirectorID", "dbo.Directors");
            DropForeignKey("dbo.ActorMovies", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.ActorMovies", "Actor_ActorId", "dbo.Actors");
            DropIndex("dbo.ActorMovies", new[] { "Movie_MovieId" });
            DropIndex("dbo.ActorMovies", new[] { "Actor_ActorId" });
            DropIndex("dbo.BackofficeUserLogins", new[] { "UserId" });
            DropIndex("dbo.BackofficeUserClaims", new[] { "UserId" });
            DropIndex("dbo.BackofficeUsers", new[] { "type_Id" });
            DropIndex("dbo.BackofficeUsers", "UserNameIndex");
            DropIndex("dbo.BackofficeUserRoles", new[] { "RoleId" });
            DropIndex("dbo.BackofficeUserRoles", new[] { "UserId" });
            DropIndex("dbo.BackofficeRoles", "RoleNameIndex");
            DropIndex("dbo.Tickets", new[] { "TicketSoortID" });
            DropIndex("dbo.Tickets", new[] { "SeatId" });
            DropIndex("dbo.Tickets", new[] { "OrderId" });
            DropIndex("dbo.RoomRows", new[] { "RoomId" });
            DropIndex("dbo.Seats", new[] { "ShowID" });
            DropIndex("dbo.Shows", new[] { "LadiesNightid" });
            DropIndex("dbo.Shows", new[] { "RoomId" });
            DropIndex("dbo.Shows", new[] { "MovieId" });
            DropIndex("dbo.Orders", new[] { "ShowID" });
            DropIndex("dbo.Movies", new[] { "Pegi_PegiId" });
            DropIndex("dbo.Movies", new[] { "Director_DirectorID" });
            DropTable("dbo.ActorMovies");
            DropTable("dbo.BackofficeUserLogins");
            DropTable("dbo.BackofficeUserClaims");
            DropTable("dbo.BackofficeUsers");
            DropTable("dbo.BackofficeUserRoles");
            DropTable("dbo.BackofficeRoles");
            DropTable("dbo.TicketSoorts");
            DropTable("dbo.Tickets");
            DropTable("dbo.RoomRows");
            DropTable("dbo.Rooms");
            DropTable("dbo.Seats");
            DropTable("dbo.Shows");
            DropTable("dbo.Orders");
            DropTable("dbo.LadiesNights");
            DropTable("dbo.Mails");
            DropTable("dbo.Pegis");
            DropTable("dbo.Actors");
            DropTable("dbo.Movies");
            DropTable("dbo.Directors");
        }
    }
}
