using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TheChat.Utility.Enums.CommonEnum;

namespace TheChat.ServerModel
{
    public class AuthenticationServerModel : BaseServerModel
    {
        [Key]
        public long Id { get; set; }

        public long User_Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Auth_Type { get; set; }

        public string Status { get; set; } = Message.InActive;

        public string Link_Name { get; set; }

        public int Failed_Login_Attempt { get; set; } = 0;

        public long? Verify_Code { get; set; } 

        public int Is_Terms_Policy { get; set; } = 1;

        public DateTime? Last_Login_Date { get; set; }

    }
}
