/**
 * Enumeration.cs
 *
 * Copyright (c) .NET Foundation and Contributors
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 *
 * References from.
 * https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/Services/Ordering/Ordering.Domain/SeedWork/Enumeration.cs
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#pragma warning disable IDE1006 //Naming rule violation

namespace Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork;

/// <summary>
/// Enumeration class in eShopOnContainers (.NET Application Architecture style).
/// </summary>
public abstract class Enumeration : IComparable
{
    public string Name { get; init; }

    public int Id { get; init; }

    protected Enumeration(int id, string name) => (Id, Name) = (id, name);

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                 .Select(f => f.GetValue(null))
                 .Cast<T>();

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode() => Id.GetHashCode();

    public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
    {
        var absoluteDifference = Math.Abs(firstValue.Id - secondValue.Id);
        return absoluteDifference;
    }

    public static T FromValue<T>(int value)
        where T : Enumeration
    {
        var matchingItem = Parse<T, int>(value, "value", item => item.Id == value);
        return matchingItem;
    }

    public static T FromDisplayName<T>(string displayName)
        where T : Enumeration
    {
        var matchingItem = Parse<T, string>(displayName, "display name", item => item.Name == displayName);
        return matchingItem;
    }

    private static T Parse<T, K>(K value, string description, Func<T, bool> predicate)
        where T : Enumeration
    {
        var matchingItem = GetAll<T>().FirstOrDefault(predicate);
        var parsed = matchingItem
            ?? throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");

        return parsed;
    }

    public int CompareTo(object? other)
        => Id.CompareTo(((Enumeration?)other)?.Id);

}
