using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class FixedCascadePaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    PictureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelativePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.PictureID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureID = table.Column<int>(type: "int", nullable: true),
                    ItemCount = table.Column<int>(type: "int", nullable: true),
                    ItemValue = table.Column<int>(type: "int", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Item_Picture_PictureID",
                        column: x => x.PictureID,
                        principalTable: "Picture",
                        principalColumn: "PictureID");
                });

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CollectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollectionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.CollectionId);
                    table.ForeignKey(
                        name: "FK_Collection_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionFolder",
                columns: table => new
                {
                    CollectionFolderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CollectionFolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollectionFolderDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionFolder", x => x.CollectionFolderID);
                    table.ForeignKey(
                        name: "FK_CollectionFolder_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingLink",
                columns: table => new
                {
                    ShoppingLinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ShoppingLinkUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoppingLinkTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoppingLinkIsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLink", x => x.ShoppingLinkID);
                    table.ForeignKey(
                        name: "FK_ShoppingLink_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PictureID = table.Column<int>(type: "int", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminUserType = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_UserProfile_Picture_PictureID",
                        column: x => x.PictureID,
                        principalTable: "Picture",
                        principalColumn: "PictureID");
                    table.ForeignKey(
                        name: "FK_UserProfile_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    WishlistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    WishlistName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.WishlistID);
                    table.ForeignKey(
                        name: "FK_Wishlist_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marketplace",
                columns: table => new
                {
                    ListingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DescriptionOfListing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemIsRequested = table.Column<bool>(type: "bit", nullable: false),
                    ListingIsActive = table.Column<bool>(type: "bit", nullable: false),
                    ListingCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marketplace", x => x.ListingID);
                    table.ForeignKey(
                        name: "FK_Marketplace_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marketplace_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Junction_Item_Collection",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    CollectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Junction_Item_Collection", x => new { x.ItemID, x.CollectionID });
                    table.ForeignKey(
                        name: "FK_Junction_Item_Collection_Collection_CollectionID",
                        column: x => x.CollectionID,
                        principalTable: "Collection",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Junction_Item_Collection_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Junction_Folder_Collection",
                columns: table => new
                {
                    CollectionFolderID = table.Column<int>(type: "int", nullable: false),
                    CollectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Junction_Folder_Collection", x => new { x.CollectionFolderID, x.CollectionID });
                    table.ForeignKey(
                        name: "FK_Junction_Folder_Collection_CollectionFolder_CollectionFolderID",
                        column: x => x.CollectionFolderID,
                        principalTable: "CollectionFolder",
                        principalColumn: "CollectionFolderID");
                    table.ForeignKey(
                        name: "FK_Junction_Folder_Collection_Collection_CollectionID",
                        column: x => x.CollectionID,
                        principalTable: "Collection",
                        principalColumn: "CollectionId");
                });

            migrationBuilder.CreateTable(
                name: "Junction_Wishlist_Item",
                columns: table => new
                {
                    WishlistID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Junction_Wishlist_Item", x => new { x.WishlistID, x.ItemID });
                    table.ForeignKey(
                        name: "FK_Junction_Wishlist_Item_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Junction_Wishlist_Item_Wishlist_WishlistID",
                        column: x => x.WishlistID,
                        principalTable: "Wishlist",
                        principalColumn: "WishlistID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chatroom",
                columns: table => new
                {
                    ConversationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingID = table.Column<int>(type: "int", nullable: true),
                    ConversationUser1ID = table.Column<int>(type: "int", nullable: false),
                    ConversationUser2ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chatroom", x => x.ConversationID);
                    table.ForeignKey(
                        name: "FK_Chatroom_Marketplace_ListingID",
                        column: x => x.ListingID,
                        principalTable: "Marketplace",
                        principalColumn: "ListingID");
                });

            migrationBuilder.CreateTable(
                name: "ChatroomMessage",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ConversationID = table.Column<int>(type: "int", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageSentAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatroomMessage", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_ChatroomMessage_Chatroom_ConversationID",
                        column: x => x.ConversationID,
                        principalTable: "Chatroom",
                        principalColumn: "ConversationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatroomMessage_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Junction_Chatroom_User",
                columns: table => new
                {
                    ConversationID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Junction_Chatroom_User", x => new { x.ConversationID, x.UserID });
                    table.ForeignKey(
                        name: "FK_Junction_Chatroom_User_Chatroom_ConversationID",
                        column: x => x.ConversationID,
                        principalTable: "Chatroom",
                        principalColumn: "ConversationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Junction_Chatroom_User_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chatroom_ListingID",
                table: "Chatroom",
                column: "ListingID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatroomMessage_ConversationID",
                table: "ChatroomMessage",
                column: "ConversationID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatroomMessage_UserID",
                table: "ChatroomMessage",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Collection_UserID",
                table: "Collection",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionFolder_UserID",
                table: "CollectionFolder",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_PictureID",
                table: "Item",
                column: "PictureID");

            migrationBuilder.CreateIndex(
                name: "IX_Junction_Chatroom_User_UserID",
                table: "Junction_Chatroom_User",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Junction_Folder_Collection_CollectionID",
                table: "Junction_Folder_Collection",
                column: "CollectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Junction_Item_Collection_CollectionID",
                table: "Junction_Item_Collection",
                column: "CollectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Junction_Wishlist_Item_ItemID",
                table: "Junction_Wishlist_Item",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Marketplace_ItemID",
                table: "Marketplace",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Marketplace_UserID",
                table: "Marketplace",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLink_UserID",
                table: "ShoppingLink",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_PictureID",
                table: "UserProfile",
                column: "PictureID");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_UserID",
                table: "Wishlist",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatroomMessage");

            migrationBuilder.DropTable(
                name: "Junction_Chatroom_User");

            migrationBuilder.DropTable(
                name: "Junction_Folder_Collection");

            migrationBuilder.DropTable(
                name: "Junction_Item_Collection");

            migrationBuilder.DropTable(
                name: "Junction_Wishlist_Item");

            migrationBuilder.DropTable(
                name: "ShoppingLink");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "Chatroom");

            migrationBuilder.DropTable(
                name: "CollectionFolder");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "Marketplace");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Picture");
        }
    }
}
