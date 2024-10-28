using Microsoft.AspNetCore.Http;



namespace TheChat.Utility.Common
{
    public class InternalServerErrorException : Exception
    {
        public static Int16 Error(Int16 errorCode)
        {
            return (errorCode > 0 ? errorCode : Convert.ToInt16(StatusCodes.Status500InternalServerError));
        }
    }
}
