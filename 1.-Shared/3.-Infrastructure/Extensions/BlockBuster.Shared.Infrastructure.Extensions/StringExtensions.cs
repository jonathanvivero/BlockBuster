using System;

namespace BlockBuster.Shared.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string Format(this string me, object param)
        {
            return string.Format(me, param);
        }

        public static string Format(this string me, object param1, object param2)
        {
            return string.Format(me, param1, param2);
        }
        
        public static string Format(this string me, params object[] args)
        {
            return string.Format(me, args);
        }
    }
}


