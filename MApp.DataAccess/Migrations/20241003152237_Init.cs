using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllUsers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    EncryptedPassword = table.Column<string>(type: "text", nullable: false),
                    EMail = table.Column<string>(type: "text", nullable: false),
                    UserLevel = table.Column<int>(type: "integer", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    Languages = table.Column<string>(type: "text", nullable: false),
                    Hobbies = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProfilePicturePath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OnlineEventCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineEventCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OnlineEventsArchived",
                columns: table => new
                {
                    onlineEventsArchivedID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    eventDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    eventTitle = table.Column<string>(type: "text", nullable: false),
                    eventDescription = table.Column<string>(type: "text", nullable: false),
                    spotsLeft = table.Column<int>(type: "integer", nullable: false),
                    categoryName = table.Column<string>(type: "text", nullable: false),
                    subcategory = table.Column<string>(type: "text", nullable: true),
                    creatorID = table.Column<int>(type: "integer", nullable: false),
                    users = table.Column<string>(type: "text", nullable: false),
                    onlineEventsID = table.Column<int>(type: "integer", nullable: false),
                    details = table.Column<string>(type: "text", nullable: false),
                    wayOfContact = table.Column<string>(type: "text", nullable: false),
                    contactDetails = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineEventsArchived", x => x.onlineEventsArchivedID);
                });

            migrationBuilder.CreateTable(
                name: "OnlineEventsDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Details = table.Column<string>(type: "text", nullable: false),
                    WayOfContact = table.Column<string>(type: "text", nullable: false),
                    ContactDetails = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineEventsDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalEventCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    CategoryColor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalEventCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalEventsArchived",
                columns: table => new
                {
                    PhysicalEventsArchivedID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    eventDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    eventDateGMT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    eventTitle = table.Column<string>(type: "text", nullable: false),
                    eventDescription = table.Column<string>(type: "text", nullable: false),
                    longtitude = table.Column<double>(type: "double precision", nullable: false),
                    latitude = table.Column<double>(type: "double precision", nullable: false),
                    spotsLeft = table.Column<int>(type: "integer", nullable: false),
                    categoryName = table.Column<string>(type: "text", nullable: false),
                    subcategory = table.Column<string>(type: "text", nullable: true),
                    creatorID = table.Column<int>(type: "integer", nullable: false),
                    users = table.Column<string>(type: "text", nullable: false),
                    physicalEventsID = table.Column<int>(type: "integer", nullable: false),
                    details = table.Column<string>(type: "text", nullable: false),
                    wayOfContact = table.Column<string>(type: "text", nullable: false),
                    contactDetails = table.Column<string>(type: "text", nullable: false),
                    howToGetThereInfo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalEventsArchived", x => x.PhysicalEventsArchivedID);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalEventsDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Details = table.Column<string>(type: "text", nullable: false),
                    WayOfContact = table.Column<string>(type: "text", nullable: false),
                    ContactDetails = table.Column<string>(type: "text", nullable: false),
                    HowToGetThereInfo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalEventsDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactInvitations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvitationAuthorID = table.Column<int>(type: "integer", nullable: false),
                    InvitedUserID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInvitations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContactInvitations_AllUsers_InvitedUserID",
                        column: x => x.InvitedUserID,
                        principalTable: "AllUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUser",
                columns: table => new
                {
                    ContactsID = table.Column<int>(type: "integer", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUser", x => new { x.ContactsID, x.UserID });
                    table.ForeignKey(
                        name: "FK_UserUser_AllUsers_ContactsID",
                        column: x => x.ContactsID,
                        principalTable: "AllUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUser_AllUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AllUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnlineEventCategoryUser",
                columns: table => new
                {
                    FavouriteForID = table.Column<int>(type: "integer", nullable: false),
                    FavouriteOnlineEventCategoriesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineEventCategoryUser", x => new { x.FavouriteForID, x.FavouriteOnlineEventCategoriesID });
                    table.ForeignKey(
                        name: "FK_OnlineEventCategoryUser_AllUsers_FavouriteForID",
                        column: x => x.FavouriteForID,
                        principalTable: "AllUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnlineEventCategoryUser_OnlineEventCategories_FavouriteOnli~",
                        column: x => x.FavouriteOnlineEventCategoriesID,
                        principalTable: "OnlineEventCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnlineEvents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EventDateGMT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EventTitle = table.Column<string>(type: "text", nullable: false),
                    EventDescription = table.Column<string>(type: "text", nullable: false),
                    SpotsLeft = table.Column<int>(type: "integer", nullable: false),
                    Spots = table.Column<int>(type: "integer", nullable: false),
                    IsUsersListPublic = table.Column<bool>(type: "boolean", nullable: false),
                    ShowAfterAllSpotsTaken = table.Column<bool>(type: "boolean", nullable: false),
                    IsEventPrivate = table.Column<bool>(type: "boolean", nullable: false),
                    EventForFriendsOnly = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryID = table.Column<int>(type: "integer", nullable: false),
                    Subcategory = table.Column<string>(type: "text", nullable: true),
                    DetailsID = table.Column<int>(type: "integer", nullable: false),
                    CreatorID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineEvents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OnlineEvents_OnlineEventCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "OnlineEventCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnlineEvents_OnlineEventsDetails_DetailsID",
                        column: x => x.DetailsID,
                        principalTable: "OnlineEventsDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalEventCategoryUser",
                columns: table => new
                {
                    FavouriteForID = table.Column<int>(type: "integer", nullable: false),
                    FavouritePhysicalEventCategoriesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalEventCategoryUser", x => new { x.FavouriteForID, x.FavouritePhysicalEventCategoriesID });
                    table.ForeignKey(
                        name: "FK_PhysicalEventCategoryUser_AllUsers_FavouriteForID",
                        column: x => x.FavouriteForID,
                        principalTable: "AllUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhysicalEventCategoryUser_PhysicalEventCategories_Favourite~",
                        column: x => x.FavouritePhysicalEventCategoriesID,
                        principalTable: "PhysicalEventCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalEvents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EventDateGMT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EventTitle = table.Column<string>(type: "text", nullable: false),
                    EventDescription = table.Column<string>(type: "text", nullable: false),
                    Longtitude = table.Column<double>(type: "double precision", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    SpotsLeft = table.Column<int>(type: "integer", nullable: false),
                    Spots = table.Column<int>(type: "integer", nullable: false),
                    IsUsersListPublic = table.Column<bool>(type: "boolean", nullable: false),
                    ShowAfterAllSpotsTaken = table.Column<bool>(type: "boolean", nullable: false),
                    IsEventPrivate = table.Column<bool>(type: "boolean", nullable: false),
                    EventForFriendsOnly = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryID = table.Column<int>(type: "integer", nullable: false),
                    Subcategory = table.Column<string>(type: "text", nullable: true),
                    DetailsID = table.Column<int>(type: "integer", nullable: false),
                    CreatorID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalEvents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhysicalEvents_PhysicalEventCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "PhysicalEventCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhysicalEvents_PhysicalEventsDetails_DetailsID",
                        column: x => x.DetailsID,
                        principalTable: "PhysicalEventsDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnlineEventAttendees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsAttending = table.Column<bool>(type: "boolean", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    EventID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineEventAttendees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OnlineEventAttendees_AllUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AllUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnlineEventAttendees_OnlineEvents_EventID",
                        column: x => x.EventID,
                        principalTable: "OnlineEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnlineEventsInvitations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvitedUserID = table.Column<int>(type: "integer", nullable: false),
                    AuthorID = table.Column<int>(type: "integer", nullable: false),
                    InvitationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EventID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineEventsInvitations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OnlineEventsInvitations_AllUsers_InvitedUserID",
                        column: x => x.InvitedUserID,
                        principalTable: "AllUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnlineEventsInvitations_OnlineEvents_EventID",
                        column: x => x.EventID,
                        principalTable: "OnlineEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventsStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorID = table.Column<int>(type: "integer", nullable: false),
                    CreationTimeGMT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    OnlineEventID = table.Column<int>(type: "integer", nullable: true),
                    PhysicalEventID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsStatuses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventsStatuses_AllUsers_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "AllUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsStatuses_OnlineEvents_OnlineEventID",
                        column: x => x.OnlineEventID,
                        principalTable: "OnlineEvents",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EventsStatuses_PhysicalEvents_PhysicalEventID",
                        column: x => x.PhysicalEventID,
                        principalTable: "PhysicalEvents",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PhysicalEventAttendees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsAttending = table.Column<bool>(type: "boolean", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    EventID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalEventAttendees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhysicalEventAttendees_AllUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AllUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhysicalEventAttendees_PhysicalEvents_EventID",
                        column: x => x.EventID,
                        principalTable: "PhysicalEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalEventsInvitations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvitedUserID = table.Column<int>(type: "integer", nullable: false),
                    AuthorID = table.Column<int>(type: "integer", nullable: false),
                    InvitationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EventID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalEventsInvitations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhysicalEventsInvitations_AllUsers_InvitedUserID",
                        column: x => x.InvitedUserID,
                        principalTable: "AllUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhysicalEventsInvitations_PhysicalEvents_EventID",
                        column: x => x.EventID,
                        principalTable: "PhysicalEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventsStatusesComments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorID = table.Column<int>(type: "integer", nullable: false),
                    CreationTimeGMT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    StatusID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsStatusesComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventsStatusesComments_AllUsers_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "AllUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsStatusesComments_EventsStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "EventsStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInvitations_InvitedUserID",
                table: "ContactInvitations",
                column: "InvitedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_EventsStatuses_CreatorID",
                table: "EventsStatuses",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_EventsStatuses_OnlineEventID",
                table: "EventsStatuses",
                column: "OnlineEventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventsStatuses_PhysicalEventID",
                table: "EventsStatuses",
                column: "PhysicalEventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventsStatusesComments_CreatorID",
                table: "EventsStatusesComments",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_EventsStatusesComments_StatusID",
                table: "EventsStatusesComments",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineEventAttendees_EventID",
                table: "OnlineEventAttendees",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineEventAttendees_UserID",
                table: "OnlineEventAttendees",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineEventCategoryUser_FavouriteOnlineEventCategoriesID",
                table: "OnlineEventCategoryUser",
                column: "FavouriteOnlineEventCategoriesID");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineEvents_CategoryID",
                table: "OnlineEvents",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineEvents_DetailsID",
                table: "OnlineEvents",
                column: "DetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineEventsInvitations_EventID",
                table: "OnlineEventsInvitations",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineEventsInvitations_InvitedUserID",
                table: "OnlineEventsInvitations",
                column: "InvitedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalEventAttendees_EventID",
                table: "PhysicalEventAttendees",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalEventAttendees_UserID",
                table: "PhysicalEventAttendees",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalEventCategoryUser_FavouritePhysicalEventCategoriesID",
                table: "PhysicalEventCategoryUser",
                column: "FavouritePhysicalEventCategoriesID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalEvents_CategoryID",
                table: "PhysicalEvents",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalEvents_DetailsID",
                table: "PhysicalEvents",
                column: "DetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalEventsInvitations_EventID",
                table: "PhysicalEventsInvitations",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalEventsInvitations_InvitedUserID",
                table: "PhysicalEventsInvitations",
                column: "InvitedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserUser_UserID",
                table: "UserUser",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInvitations");

            migrationBuilder.DropTable(
                name: "EventsStatusesComments");

            migrationBuilder.DropTable(
                name: "OnlineEventAttendees");

            migrationBuilder.DropTable(
                name: "OnlineEventCategoryUser");

            migrationBuilder.DropTable(
                name: "OnlineEventsArchived");

            migrationBuilder.DropTable(
                name: "OnlineEventsInvitations");

            migrationBuilder.DropTable(
                name: "PhysicalEventAttendees");

            migrationBuilder.DropTable(
                name: "PhysicalEventCategoryUser");

            migrationBuilder.DropTable(
                name: "PhysicalEventsArchived");

            migrationBuilder.DropTable(
                name: "PhysicalEventsInvitations");

            migrationBuilder.DropTable(
                name: "UserUser");

            migrationBuilder.DropTable(
                name: "EventsStatuses");

            migrationBuilder.DropTable(
                name: "AllUsers");

            migrationBuilder.DropTable(
                name: "OnlineEvents");

            migrationBuilder.DropTable(
                name: "PhysicalEvents");

            migrationBuilder.DropTable(
                name: "OnlineEventCategories");

            migrationBuilder.DropTable(
                name: "OnlineEventsDetails");

            migrationBuilder.DropTable(
                name: "PhysicalEventCategories");

            migrationBuilder.DropTable(
                name: "PhysicalEventsDetails");
        }
    }
}
