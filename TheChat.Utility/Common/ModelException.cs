using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TheChat.Utility.Common
{
    public class ModelException
    {
        public static string Errors(ModelStateDictionary modelState)
        {
            return string.Join(" | ", modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
        }
    }
}
