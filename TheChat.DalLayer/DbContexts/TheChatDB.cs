
using Microsoft.EntityFrameworkCore;
using TheChat.ServerModel;

namespace TheChat.DalLayer.DbContexts
{
    public class TheChatDB : DbContext
    {
        public TheChatDB(DbContextOptions<TheChatDB> options) : base(options)
        {

        }
        public void BeginTransaction(short CommandTimeout = 180)
        {
            base.Database.SetCommandTimeout(CommandTimeout);
            base.Database.BeginTransaction();
        }

        public void CommitTransaction(short CommandTimeout = 180)
        {
            base.Database.SetCommandTimeout(CommandTimeout);
            base.Database.CommitTransaction();
        }

        public void RollBackTransaction(short CommandTimeout = 180)
        {
            base.Database.SetCommandTimeout(CommandTimeout);
            base.Database.RollbackTransaction();
        }

        public DbSet<ChatServerModel> ChatModel { get; set; }

        public DbSet<AuthenticationServerModel> AuthenticationModel { get; set; }

        public DbSet<AuthenticationDetailsServerModel> AuthenticationDetailsModel { get; set; }

        public DbSet<ConversationServerModel> ConversationModel { get; set; }

        public DbSet<ConversationDetailsServerModel> ConversationDetailsModel { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatServerModel>().ToTable("tbl_chats");
            modelBuilder.Entity<AuthenticationServerModel>().ToTable("tbl_Authentication");
            modelBuilder.Entity<AuthenticationDetailsServerModel>().ToTable("tbl_Authentication_Details");
            modelBuilder.Entity<ConversationServerModel>().ToTable("tbl_Conversation");
            modelBuilder.Entity<ConversationDetailsServerModel>().ToTable("tbl_Conversation_Details");
        }
    }
}
