using System;
using System.ComponentModel;
using System.Reflection;

namespace Common.ExtensionMethods
{
    public static class EnumerationExtension
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            var attribute
                = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                  as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
