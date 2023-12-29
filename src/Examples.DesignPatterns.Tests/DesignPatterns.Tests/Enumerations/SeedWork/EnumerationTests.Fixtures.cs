using Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork;

#pragma warning disable IDE1006 //Naming rule violation

namespace Examples.DesignPatterns.Enumerations.SeedWork.Tests;

public partial class EnumerationTests
{
    public class CardType : Enumeration
    {
        public static readonly CardType Amex = new(1, nameof(Amex), () => nameof(Amex));
        public static readonly CardType Visa = new(2, nameof(Visa), () => nameof(Visa));
        public static readonly CardType MasterCard = new(3, nameof(MasterCard), () => nameof(MasterCard));

        private readonly Func<string> _provider;

        public string GetProvider() => $"this card is {_provider()}.";

        private CardType(int id, string name, Func<string> provider)
            : base(id, name)
        {
            _provider = provider;
        }

    }

}
