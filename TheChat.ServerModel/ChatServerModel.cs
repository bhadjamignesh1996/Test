using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheChat.ServerModel
{
    public class ChatServerModel
    {
        [Key]
        public long id { get; set; }

        public string title { get; set; }

        public string model_name { get; set; }

        public long user_id { get; set; }

        public DateTime last_chat_date { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }
    }
}
