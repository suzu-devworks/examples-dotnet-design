using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Examples.Enumerations;

public interface IEnumeration<T> where T : IEnumeration<T>
{
    bool IsMatch(string value);

    public static IEnumerable<T> GetAll() =>
        typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                 .Select(f => f.GetValue(null))
                 .Cast<T>();

    public static T? Parse(string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        var entry = GetAll().FirstOrDefault(x => x.IsMatch(value));
        var parsed = entry ?? default;

        return parsed;
    }

}
