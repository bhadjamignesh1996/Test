using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheChat.ServerModel
{
    public class ConversationDetailsServerModel : BaseServerModel
    {
        [Key]
        public long Id { get; set; }

        public long Conversation_Id { get; set; }

        public string Message { get; set; }

        public string Role { get; set; }

        public int Model_Id { get; set; }

        public long Parent_Id { get; set; } = 0;

        public long Is_EditId { get; set; } = 0;

       
    }
}
