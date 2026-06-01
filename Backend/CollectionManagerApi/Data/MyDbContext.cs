using CollectionManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CollectionManagerApi.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions <MyDbContext> options) : base(options)
        {
        }

        public DbSet<Chatroom_UserModel> Junction_Chatroom_User => Set<Chatroom_UserModel>();
        public DbSet<ChatroomMessageModel> ChatroomMessage => Set<ChatroomMessageModel>();
        public DbSet<ChatroomModel> Chatroom => Set<ChatroomModel>();
        public DbSet<CollectionFolder_CollectionModel> Junction_Folder_Collection => Set<CollectionFolder_CollectionModel>();
        public DbSet<CollectionFolderModel> ColelctionFolder => Set<CollectionFolderModel>();
        public DbSet<CollectionModel> Collection => Set<CollectionModel>();
        public DbSet<Item_CollectionModel> Junction_Item_Collection => Set<Item_CollectionModel>();
        public DbSet<ItemModel> Item => Set<ItemModel>();
        public DbSet<MarketplaceListingModel> Marketplace => Set<MarketplaceListingModel>();
        public DbSet<PictureModel> Picture => Set<PictureModel>();
        public DbSet<ShoppingLinkModel> ShoppingLink => Set<ShoppingLinkModel>();
        public DbSet<UserLoginModel> UserLogin => Set<UserLoginModel>();
        public DbSet<UserModel> User => Set<UserModel>();
        public DbSet<UserProfileModel> UserProfile => Set<UserProfileModel>();
        public DbSet<Wishlist_ItemModel> Junction_Wishlist_Item => Set<Wishlist_ItemModel>();
        public DbSet<WishlistModel> Wishlist => Set<WishlistModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<>()
                .HasOne
        }
    }
}