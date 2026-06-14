using CollectionManagerApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CollectionManagerApi.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Chatroom_User> Junction_Chatroom_User => Set<Chatroom_User>();
        public DbSet<ChatroomMessage> ChatroomMessage => Set<ChatroomMessage>();
        public DbSet<Chatroom> Chatroom => Set<Chatroom>();
        public DbSet<CollectionFolder_Collection> Junction_Folder_Collection => Set<CollectionFolder_Collection>();
        public DbSet<CollectionFolder> CollectionFolder => Set<CollectionFolder>();
        public DbSet<Collection> Collection => Set<Collection>();
        public DbSet<Item_Collection> Junction_Item_Collection => Set<Item_Collection>();
        public DbSet<Item> Item => Set<Item>();
        public DbSet<MarketplaceListing> Marketplace => Set<MarketplaceListing>();
        public DbSet<Picture> Picture => Set<Picture>();
        public DbSet<ShoppingLink> ShoppingLink => Set<ShoppingLink>();
        public DbSet<UserLogin> UserLogin => Set<UserLogin>();
        public DbSet<User> User => Set<User>();
        public DbSet<UserProfile> UserProfile => Set<UserProfile>();
        public DbSet<Wishlist_Item> Junction_Wishlist_Item => Set<Wishlist_Item>();
        public DbSet<Wishlist> Wishlist => Set<Wishlist>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //UserLogin - 1:1 med User
            modelBuilder.Entity<UserLogin>()
                .HasKey(ul => ul.UserID);

            modelBuilder.Entity<UserLogin>()
                .HasOne(ul => ul.User)
                .WithOne(u => u.UserLogin)
                .HasForeignKey<UserLogin>(ul => ul.UserID);

            //UserProfile - 1:1 med User
            modelBuilder.Entity<UserProfile>()
                .HasKey(ul => ul.UserID);

            modelBuilder.Entity<UserProfile>()
                .HasOne(up => up.User)
                .WithOne(u => u.UserProfile)
                .HasForeignKey<UserProfile>(up => up.UserID);

            //Chatroom - 1:m med MarketplaceListing
            modelBuilder.Entity<Chatroom>()
                .HasKey(c => c.ConversationID);

            modelBuilder.Entity<Chatroom>()
                .HasOne(c => c.MarketplaceListing)
                .WithMany(ml => ml.Chatroom)
                .HasForeignKey(c => c.ListingID);

            //ChatroomMessage - 1:m med Chatroom
            modelBuilder.Entity<ChatroomMessage>()
                .HasKey(cm => cm.MessageID);
            
            modelBuilder.Entity<ChatroomMessage>()
                .HasOne(cm => cm.Chatroom)
                .WithMany(c => c.ChatroomMessage)
                .HasForeignKey(cm => cm.ConversationID);

            //ChatroomMessage - 1:m med User
            modelBuilder.Entity<ChatroomMessage>()
                .HasKey(cm => cm.MessageID);

            modelBuilder.Entity<ChatroomMessage>()
                .HasOne(cm => cm.User)
                .WithMany(u => u.ChatroomMessage)
                .HasForeignKey(cm => cm.UserID);

            //Collection - 1:m med User
            modelBuilder.Entity<Collection>()
                .HasOne(c => c.User)
                .WithMany(u => u.Collection)
                .HasForeignKey(c => c.UserID);

            //CollectionFolder - 1:m med User
            modelBuilder.Entity<CollectionFolder>()
                .HasOne(cf => cf.User)
                .WithMany(u => u.CollectionFolder)
                .HasForeignKey(cf => cf.UserID);

            //Item - 1:m med Picture
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Picture)
                .WithMany(p => p.Item)
                .HasForeignKey(i => i.PictureID);

            //MarketplaceListing - 1:m med Item
            modelBuilder.Entity<MarketplaceListing>()
                .HasKey(ml => ml.ListingID);
            
            modelBuilder.Entity<MarketplaceListing>()
                .HasOne(ml => ml.Item)
                .WithMany(i => i.MarketplaceListing)
                .HasForeignKey(ml => ml.ItemID);

            //MarketplaceListing - 1:m med User
            modelBuilder.Entity<MarketplaceListing>()
                .HasKey(ml => ml.ListingID);

            modelBuilder.Entity<MarketplaceListing>()
                .HasOne(ml => ml.User)
                .WithMany(u => u.MarketplaceListing)
                .HasForeignKey(ml => ml.UserID);

            //ShoppingLink - 1:m med User
            modelBuilder.Entity<ShoppingLink>()
                .HasOne(sl => sl.User)
                .WithMany(u => u.ShoppingLink)
                .HasForeignKey(sl => sl.UserID);

            //Wishlist - 1:m med User
            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.User)
                .WithMany(u => u.Wishlist)
                .HasForeignKey(w => w.UserID);

            //Chatroom_User - m:m med Chatroom og User
            modelBuilder.Entity<Chatroom_User>()
                .HasKey(c_u => new {c_u.ConversationID, c_u.UserID});

            modelBuilder.Entity<Chatroom_User>()
                .HasOne(c_u => c_u.Chatroom)
                .WithMany(c => c.Chatroom_User)
                .HasForeignKey(c_u => c_u.ConversationID);

            modelBuilder.Entity<Chatroom_User>()
                .HasOne(c_u => c_u.User)
                .WithMany(u => u.Chatroom_User)
                .HasForeignKey(c_u => c_u.UserID);

            //CollectionFolder_Collection - m:m med CollectionFolder og Collection
            modelBuilder.Entity<CollectionFolder_Collection>()
                .HasKey(cf_c => new {cf_c.CollectionFolderID, cf_c.CollectionID});

            modelBuilder.Entity<CollectionFolder_Collection>()
                .HasOne(cf_c => cf_c.CollectionFolder)
                .WithMany(cf => cf.CollectionFolder_Collection)
                .HasForeignKey(cf_c => cf_c.CollectionFolderID);

            modelBuilder.Entity<CollectionFolder_Collection>()
                .HasOne(cf_c => cf_c.Collection)
                .WithMany(c => c.CollectionFolder_Collection)
                .HasForeignKey(cf_c => cf_c.CollectionID);

            //Item_Collection - m:m med Item og Collection
            modelBuilder.Entity<Item_Collection>()
                .HasKey(i_c => new {i_c.ItemID, i_c.CollectionID});

            modelBuilder.Entity<Item_Collection>()
                .HasOne(i_c => i_c.Item)
                .WithMany(i => i.Item_Collection)
                .HasForeignKey(i_c => i_c.ItemID);

            modelBuilder.Entity<Item_Collection>()
                .HasOne(i_c => i_c.Collection)
                .WithMany(c => c.Item_Collection)
                .HasForeignKey(i_c => i_c.CollectionID);

            //Wishlist_Item - m:m med Wishlist og Item
            modelBuilder.Entity<Wishlist_Item>()
                .HasKey(w_i => new {w_i.WishlistID, w_i.ItemID});

            modelBuilder.Entity<Wishlist_Item>()
                .HasOne(w_i => w_i.Wishlist)
                .WithMany(w => w.Wishlist_Item)
                .HasForeignKey(w_i => w_i.WishlistID);

            modelBuilder.Entity<Wishlist_Item>()
                .HasOne(w_i => w_i.Item)
                .WithMany(i => i.Wishlist_Item)
                .HasForeignKey(w_i => w_i.ItemID);
        }
    }
}