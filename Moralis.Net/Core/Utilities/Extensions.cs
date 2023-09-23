﻿using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

namespace Moralis.Net.Core.Utilities
{
    public static class Extensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString());
            if (memberInfo.Length > 0)
            {
                var displayAttribute = memberInfo[0].GetCustomAttribute<DisplayAttribute>();
                if (displayAttribute != null && !string.IsNullOrEmpty(displayAttribute.GetName()))
                {
                    return displayAttribute.GetName() ?? "";
                }
            }
            return enumValue.ToString();
        }

        public static string FormatDateTime(this DateTime dateTime, string format)
        {
            var formattedDateTime = dateTime.ToString(format, CultureInfo.InvariantCulture);
            return formattedDateTime;
        }
    }
}
