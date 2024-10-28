
namespace TheChat.Utility.Common { 
    sealed public class ResponseHelper
    {
        public Int16 Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; } = null; //user <T> generic data type passing as object
    }

}
