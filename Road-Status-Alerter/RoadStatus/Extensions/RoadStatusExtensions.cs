using System;
using System.Linq;
using System.Reflection;

namespace RoadStatus.Extensions
{
    public static class RoadStatusExtensions
    {
        public static string GetDisplayName(this PropertyInfo property)
        {
            var customAttribute = property.CustomAttributes
                            .FirstOrDefault();
            return Convert.ToString(
                customAttribute
                .NamedArguments.FirstOrDefault().TypedValue);
        }
    }
}
