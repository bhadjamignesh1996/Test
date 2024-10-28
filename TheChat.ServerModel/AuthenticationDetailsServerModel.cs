using System.ComponentModel.DataAnnotations;


namespace TheChat.ServerModel
{
    public class AuthenticationDetailsServerModel : BaseServerModel
    {
        [Key]
        public long Id { get; set; }

        public long User_Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public int? Isd_Code { get; set; }

        public string? Phone_Number { get; set; }

        public string? Organization_Name { get; set; }

        public DateTime DOB { get; set; }

        public string? Profile_Image { get; set; }

        public string? Bio { get; set; }

        
    }
}
