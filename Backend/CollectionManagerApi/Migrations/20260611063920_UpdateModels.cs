using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatroomMessage_Chatroom_ChatroomModelConversationID",
                table: "ChatroomMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_Collection_ColelctionFolder_CollectionFolderModelCollectionFolderID",
                table: "Collection");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Collection_CollectionModelCollectionId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Wishlist_WishlistModelUserID",
                table: "Item");

            migrationBuilder.DropTable(
                name: "ColelctionFolder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wishlist",
                table: "Wishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Junction_Folder_Collection",
                table: "Junction_Folder_Collection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Junction_Chatroom_User",
                table: "Junction_Chatroom_User");

            migrationBuilder.DropIndex(
                name: "IX_Item_CollectionModelCollectionId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_WishlistModelUserID",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Collection_CollectionFolderModelCollectionFolderID",
                table: "Collection");

            migrationBuilder.DropIndex(
                name: "IX_ChatroomMessage_ChatroomModelConversationID",
                table: "ChatroomMessage");

            migrationBuilder.DropColumn(
                name: "ItemID",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "CollectionModelCollectionId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "WishlistModelUserID",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CollectionFolderModelCollectionFolderID",
                table: "Collection");

            migrationBuilder.DropColumn(
                name: "ChatroomModelConversationID",
                table: "ChatroomMessage");

            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "Picture",
                newName: "RelativePath");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Junction_Wishlist_Item",
                newName: "WishlistID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Wishlist",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "WishlistID",
                table: "Wishlist",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "WishlistName",
                table: "Wishlist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "UserProfile",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "UserLogin",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Picture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginalFileName",
                table: "Picture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PublicID",
                table: "Picture",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "ListingID",
                table: "Chatroom",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wishlist",
                table: "Wishlist",
                column: "WishlistID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Junction_Folder_Collection",
                table: "Junction_Folder_Collection",
                columns: new[] { "CollectionFolderID", "CollectionID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Junction_Chatroom_User",
                table: "Junction_Chatroom_User",
                columns: new[] { "ConversationID", "UserID" });

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
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_UserID",
                table: "Wishlist",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLink_UserID",
                table: "ShoppingLink",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Marketplace_ItemID",
                table: "Marketplace",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Marketplace_UserID",
                table: "Marketplace",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Junction_Wishlist_Item_ItemID",
                table: "Junction_Wishlist_Item",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Junction_Item_Collection_CollectionID",
                table: "Junction_Item_Collection",
                column: "CollectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Junction_Folder_Collection_CollectionID",
                table: "Junction_Folder_Collection",
                column: "CollectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Junction_Chatroom_User_UserID",
                table: "Junction_Chatroom_User",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Collection_UserID",
                table: "Collection",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatroomMessage_ConversationID",
                table: "ChatroomMessage",
                column: "ConversationID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatroomMessage_UserID",
                table: "ChatroomMessage",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Chatroom_ListingID",
                table: "Chatroom",
                column: "ListingID");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionFolder_UserID",
                table: "CollectionFolder",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chatroom_Marketplace_ListingID",
                table: "Chatroom",
                column: "ListingID",
                principalTable: "Marketplace",
                principalColumn: "ListingID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatroomMessage_Chatroom_ConversationID",
                table: "ChatroomMessage",
                column: "ConversationID",
                principalTable: "Chatroom",
                principalColumn: "ConversationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatroomMessage_User_UserID",
                table: "ChatroomMessage",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_User_UserID",
                table: "Collection",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junction_Chatroom_User_Chatroom_ConversationID",
                table: "Junction_Chatroom_User",
                column: "ConversationID",
                principalTable: "Chatroom",
                principalColumn: "ConversationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junction_Chatroom_User_User_UserID",
                table: "Junction_Chatroom_User",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junction_Folder_Collection_CollectionFolder_CollectionFolderID",
                table: "Junction_Folder_Collection",
                column: "CollectionFolderID",
                principalTable: "CollectionFolder",
                principalColumn: "CollectionFolderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junction_Folder_Collection_Collection_CollectionID",
                table: "Junction_Folder_Collection",
                column: "CollectionID",
                principalTable: "Collection",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junction_Item_Collection_Collection_CollectionID",
                table: "Junction_Item_Collection",
                column: "CollectionID",
                principalTable: "Collection",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junction_Item_Collection_Item_ItemID",
                table: "Junction_Item_Collection",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junction_Wishlist_Item_Item_ItemID",
                table: "Junction_Wishlist_Item",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junction_Wishlist_Item_Wishlist_WishlistID",
                table: "Junction_Wishlist_Item",
                column: "WishlistID",
                principalTable: "Wishlist",
                principalColumn: "WishlistID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marketplace_Item_ItemID",
                table: "Marketplace",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marketplace_User_UserID",
                table: "Marketplace",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLink_User_UserID",
                table: "ShoppingLink",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogin_User_UserID",
                table: "UserLogin",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_User_UserID",
                table: "UserProfile",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_User_UserID",
                table: "Wishlist",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chatroom_Marketplace_ListingID",
                table: "Chatroom");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatroomMessage_Chatroom_ConversationID",
                table: "ChatroomMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatroomMessage_User_UserID",
                table: "ChatroomMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_Collection_User_UserID",
                table: "Collection");

            migrationBuilder.DropForeignKey(
                name: "FK_Junction_Chatroom_User_Chatroom_ConversationID",
                table: "Junction_Chatroom_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Junction_Chatroom_User_User_UserID",
                table: "Junction_Chatroom_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Junction_Folder_Collection_CollectionFolder_CollectionFolderID",
                table: "Junction_Folder_Collection");

            migrationBuilder.DropForeignKey(
                name: "FK_Junction_Folder_Collection_Collection_CollectionID",
                table: "Junction_Folder_Collection");

            migrationBuilder.DropForeignKey(
                name: "FK_Junction_Item_Collection_Collection_CollectionID",
                table: "Junction_Item_Collection");

            migrationBuilder.DropForeignKey(
                name: "FK_Junction_Item_Collection_Item_ItemID",
                table: "Junction_Item_Collection");

            migrationBuilder.DropForeignKey(
                name: "FK_Junction_Wishlist_Item_Item_ItemID",
                table: "Junction_Wishlist_Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Junction_Wishlist_Item_Wishlist_WishlistID",
                table: "Junction_Wishlist_Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Marketplace_Item_ItemID",
                table: "Marketplace");

            migrationBuilder.DropForeignKey(
                name: "FK_Marketplace_User_UserID",
                table: "Marketplace");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLink_User_UserID",
                table: "ShoppingLink");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogin_User_UserID",
                table: "UserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_User_UserID",
                table: "UserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_User_UserID",
                table: "Wishlist");

            migrationBuilder.DropTable(
                name: "CollectionFolder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wishlist",
                table: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Wishlist_UserID",
                table: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLink_UserID",
                table: "ShoppingLink");

            migrationBuilder.DropIndex(
                name: "IX_Marketplace_ItemID",
                table: "Marketplace");

            migrationBuilder.DropIndex(
                name: "IX_Marketplace_UserID",
                table: "Marketplace");

            migrationBuilder.DropIndex(
                name: "IX_Junction_Wishlist_Item_ItemID",
                table: "Junction_Wishlist_Item");

            migrationBuilder.DropIndex(
                name: "IX_Junction_Item_Collection_CollectionID",
                table: "Junction_Item_Collection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Junction_Folder_Collection",
                table: "Junction_Folder_Collection");

            migrationBuilder.DropIndex(
                name: "IX_Junction_Folder_Collection_CollectionID",
                table: "Junction_Folder_Collection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Junction_Chatroom_User",
                table: "Junction_Chatroom_User");

            migrationBuilder.DropIndex(
                name: "IX_Junction_Chatroom_User_UserID",
                table: "Junction_Chatroom_User");

            migrationBuilder.DropIndex(
                name: "IX_Collection_UserID",
                table: "Collection");

            migrationBuilder.DropIndex(
                name: "IX_ChatroomMessage_ConversationID",
                table: "ChatroomMessage");

            migrationBuilder.DropIndex(
                name: "IX_ChatroomMessage_UserID",
                table: "ChatroomMessage");

            migrationBuilder.DropIndex(
                name: "IX_Chatroom_ListingID",
                table: "Chatroom");

            migrationBuilder.DropColumn(
                name: "WishlistID",
                table: "Wishlist");

            migrationBuilder.DropColumn(
                name: "WishlistName",
                table: "Wishlist");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "OriginalFileName",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "PublicID",
                table: "Picture");

            migrationBuilder.RenameColumn(
                name: "RelativePath",
                table: "Picture",
                newName: "PictureUrl");

            migrationBuilder.RenameColumn(
                name: "WishlistID",
                table: "Junction_Wishlist_Item",
                newName: "UserID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Wishlist",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "UserProfile",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "UserLogin",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ItemID",
                table: "Picture",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CollectionModelCollectionId",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WishlistModelUserID",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollectionFolderModelCollectionFolderID",
                table: "Collection",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChatroomModelConversationID",
                table: "ChatroomMessage",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ListingID",
                table: "Chatroom",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wishlist",
                table: "Wishlist",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Junction_Folder_Collection",
                table: "Junction_Folder_Collection",
                columns: new[] { "CollectionID", "CollectionFolderID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Junction_Chatroom_User",
                table: "Junction_Chatroom_User",
                columns: new[] { "UserID", "ConversationID" });

            migrationBuilder.CreateTable(
                name: "ColelctionFolder",
                columns: table => new
                {
                    CollectionFolderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionFolderDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectionFolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColelctionFolder", x => x.CollectionFolderID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_CollectionModelCollectionId",
                table: "Item",
                column: "CollectionModelCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_WishlistModelUserID",
                table: "Item",
                column: "WishlistModelUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Collection_CollectionFolderModelCollectionFolderID",
                table: "Collection",
                column: "CollectionFolderModelCollectionFolderID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatroomMessage_ChatroomModelConversationID",
                table: "ChatroomMessage",
                column: "ChatroomModelConversationID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatroomMessage_Chatroom_ChatroomModelConversationID",
                table: "ChatroomMessage",
                column: "ChatroomModelConversationID",
                principalTable: "Chatroom",
                principalColumn: "ConversationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_ColelctionFolder_CollectionFolderModelCollectionFolderID",
                table: "Collection",
                column: "CollectionFolderModelCollectionFolderID",
                principalTable: "ColelctionFolder",
                principalColumn: "CollectionFolderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Collection_CollectionModelCollectionId",
                table: "Item",
                column: "CollectionModelCollectionId",
                principalTable: "Collection",
                principalColumn: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Wishlist_WishlistModelUserID",
                table: "Item",
                column: "WishlistModelUserID",
                principalTable: "Wishlist",
                principalColumn: "UserID");
        }
    }
}
