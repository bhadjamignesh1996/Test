using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheChat.ServerModel
{
    public class ConversationServerModel : BaseServerModel
    {
        [Key]
        public long Id { get; set; }

        public long User_Id { get; set; }

        public string Title { get; set; }

        public int Is_Save { get; set; } = 0;
    }
}
