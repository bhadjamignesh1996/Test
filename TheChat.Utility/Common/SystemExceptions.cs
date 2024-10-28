
namespace TheChat.Utility.Common
{
    public class SystemExceptions : Exception
    {
        public SystemExceptions(string message, object inner) : base(message)
        {
            base.Data.Add("ErrorCode", inner);
        }
    }
}
