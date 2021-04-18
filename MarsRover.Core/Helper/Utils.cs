using System;

namespace MarsRover.Core.Helper
{
    public static class Utils
    {
        public static T ConvertToEnum<T>(this char value, T defaultValue) where T : struct
        {
            if (value.ToString().IsNullOrWhitespace())
            {
                return defaultValue;
            }

            return Enum.TryParse<T>(value.ToString(), true, out T result) ? result : defaultValue;
        }

        public static T ConvertToEnum<T>(this string value, T defaultValue) where T : struct
        {
            if (value.IsNullOrWhitespace())
            {
                return defaultValue;
            }

            return Enum.TryParse<T>(value, true, out T result) ? result : defaultValue;
        }
        public static bool IsNullOrWhitespace(this object obj)
        {
            string str = obj == DBNull.Value || obj == null ? "" : obj.ToString();
            return string.IsNullOrWhiteSpace(str);
        }

       

     
    }
}
