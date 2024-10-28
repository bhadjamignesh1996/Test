namespace TheChat.ServerModel
{
    public class BaseServerModel
    {
        public DateTime created_date { get; set; } = DateTime.Now;
        public DateTime? last_updated_date { get; set; }

    }
}
