using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chatroom",
                columns: table => new
                {
                    ConversationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingID = table.Column<int>(type: "int", nullable: false),
                    ConversationUser1ID = table.Column<int>(type: "int", nullable: false),
                    ConversationUser2ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chatroom", x => x.ConversationID);
                });

            migrationBuilder.CreateTable(
                name: "ColelctionFolder",
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
                    table.PrimaryKey("PK_ColelctionFolder", x => x.CollectionFolderID);
                });

            migrationBuilder.CreateTable(
                name: "Junction_Chatroom_User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ConversationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Junction_Chatroom_User", x => new { x.UserID, x.ConversationID });
                });

            migrationBuilder.CreateTable(
                name: "Junction_Folder_Collection",
                columns: table => new
                {
                    CollectionID = table.Column<int>(type: "int", nullable: false),
                    CollectionFolderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Junction_Folder_Collection", x => new { x.CollectionID, x.CollectionFolderID });
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
                });

            migrationBuilder.CreateTable(
                name: "Junction_Wishlist_Item",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Junction_Wishlist_Item", x => new { x.UserID, x.ItemID });
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
                    ListingCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemIsRequested = table.Column<bool>(type: "bit", nullable: false),
                    ListingIsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marketplace", x => x.ListingID);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    PictureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.PictureID);
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
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.UserID);
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
                    MessageSentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChatroomModelConversationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatroomMessage", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_ChatroomMessage_Chatroom_ChatroomModelConversationID",
                        column: x => x.ChatroomModelConversationID,
                        principalTable: "Chatroom",
                        principalColumn: "ConversationID");
                });

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CollectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollectionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectionFolderModelCollectionFolderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.CollectionId);
                    table.ForeignKey(
                        name: "FK_Collection_ColelctionFolder_CollectionFolderModelCollectionFolderID",
                        column: x => x.CollectionFolderModelCollectionFolderID,
                        principalTable: "ColelctionFolder",
                        principalColumn: "CollectionFolderID");
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureID = table.Column<int>(type: "int", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PictureID = table.Column<int>(type: "int", nullable: true),
                    ItemCount = table.Column<int>(type: "int", nullable: true),
                    ItemValue = table.Column<int>(type: "int", nullable: true),
                    CollectionModelCollectionId = table.Column<int>(type: "int", nullable: true),
                    WishlistModelUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Item_Collection_CollectionModelCollectionId",
                        column: x => x.CollectionModelCollectionId,
                        principalTable: "Collection",
                        principalColumn: "CollectionId");
                    table.ForeignKey(
                        name: "FK_Item_Picture_PictureID",
                        column: x => x.PictureID,
                        principalTable: "Picture",
                        principalColumn: "PictureID");
                    table.ForeignKey(
                        name: "FK_Item_Wishlist_WishlistModelUserID",
                        column: x => x.WishlistModelUserID,
                        principalTable: "Wishlist",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatroomMessage_ChatroomModelConversationID",
                table: "ChatroomMessage",
                column: "ChatroomModelConversationID");

            migrationBuilder.CreateIndex(
                name: "IX_Collection_CollectionFolderModelCollectionFolderID",
                table: "Collection",
                column: "CollectionFolderModelCollectionFolderID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CollectionModelCollectionId",
                table: "Item",
                column: "CollectionModelCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_PictureID",
                table: "Item",
                column: "PictureID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_WishlistModelUserID",
                table: "Item",
                column: "WishlistModelUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_PictureID",
                table: "UserProfile",
                column: "PictureID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatroomMessage");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Junction_Chatroom_User");

            migrationBuilder.DropTable(
                name: "Junction_Folder_Collection");

            migrationBuilder.DropTable(
                name: "Junction_Item_Collection");

            migrationBuilder.DropTable(
                name: "Junction_Wishlist_Item");

            migrationBuilder.DropTable(
                name: "Marketplace");

            migrationBuilder.DropTable(
                name: "ShoppingLink");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "Chatroom");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "ColelctionFolder");
        }
    }
}
