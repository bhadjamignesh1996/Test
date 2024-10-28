namespace TheChat.Utility.Common
{
    public class ConvertValue
    {
        public static string CheckIsNullOrEmpty(string val)
        {
            return String.IsNullOrEmpty(val) ? null : val.Trim();
        }

        public static int StringToInt(string val)
        {
            return String.IsNullOrEmpty(val) ? 0 : Convert.ToInt32(val) ;
        }

        public static Int64 StringToBigInt(string val)
        {
            return String.IsNullOrEmpty(val) ? 0 : Convert.ToInt64(val);
        }

        public static int BooleanToInt(bool val)
        {
            return val ? 1 : 0;
        }

        public static bool IntToBoolean(int? val)
        {
            return val == 1 ? true : false;
        }

        public static int RandomNumber()
        {
            Random random = new Random();
            return random.Next(10000000, 99999999);
        }


    }
}
