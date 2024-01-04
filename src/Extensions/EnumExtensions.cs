
using System;
using System.ComponentModel;

using iTin.Core.ComponentModel;

namespace iTin.Core.Hardware.Common;

/// <summary>
/// Provides extension methods for working with enums.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Returns the value of attribute of type <see cref="EnumDescriptionAttribute"/> for this enum value. 
    /// If this attribute is not defined returns <see langword="null"/>.
    /// </summary>
    /// <param name="value">Target enum value.</param>
    /// <returns>
    /// A <see cref="string"/> that contains the value of attribute.
    /// </returns>
    public static string GetPropertyDescription(this Enum value)
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        if (name == null)
        {
            return null;
        }

        var field = type.GetField(name);
        if (field == null)
        {
            return null;
        }

        DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(PropertyDescriptionAttribute)) as PropertyDescriptionAttribute;
        return attr?.Description;
    }

    /// <summary>
    /// Returns the value of attribute of type <see cref="EnumDescriptionAttribute"/> for this enum value. 
    /// If this attribute is not defined returns <see langword="null"/>.
    /// </summary>
    /// <param name="value">Target enum value.</param>
    /// <returns>
    /// A <see cref="string"/> that contains the value of attribute.
    /// </returns>
    public static string GetPropertyName(this Enum value)
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        if (name == null)
        {
            return null;
        }

        var field = type.GetField(name);
        if (field == null)
        {
            return null;
        }

        var attr = Attribute.GetCustomAttribute(field, typeof(PropertyNameAttribute)) as PropertyNameAttribute;
        return attr?.Name;
    }

    /// <summary>
    /// Returns the value of attribute of type <see cref="EnumDescriptionAttribute"/> for this enum value. 
    /// If this attribute is not defined returns <see langword="null"/>.
    /// </summary>
    /// <param name="value">Target enum value.</param>
    /// <returns>
    /// A <see cref="string"/> that contains the value of attribute.
    /// </returns>
    public static Type GetPropertyType(this Enum value)
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        if (name == null)
        {
            return null;
        }

        var field = type.GetField(name);
        if (field == null)
        {
            return null;
        }

        var attr = Attribute.GetCustomAttribute(field, typeof(PropertyTypeAttribute)) as PropertyTypeAttribute;
        return attr?.PropertyType;
    }
}
