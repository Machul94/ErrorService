using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorService.Domains;

namespace ErrorService.Converter
{
    public static class ErrorConverter
    {
        public static string ToSmsContent(this List<Error> errors)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Error error in errors)
            {
                sb.Append($"{error.Date.ToString("dd-MM-yyyy HH:mm")} {error.Message}{Environment.NewLine}");
                
            }
            return sb.ToString();
        }
    }
}
