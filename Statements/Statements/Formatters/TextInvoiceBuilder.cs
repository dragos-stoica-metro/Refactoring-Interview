using System.Collections.Generic;

namespace Statements.Formatters;

public class TextInvoiceBuilder : IInvoiceBuilder
{
    private const string Format = "{0:C}";
    private readonly List<string> _parts = new();

    public IInvoiceBuilder AddHeader(string customerName)
    {
        _parts.Add($"Statement for {customerName}\n");
        return this;
    }

    public IInvoiceBuilder AddPlay(string playName, double playAmount, int audience)
    {
        _parts.Add($"{playName}: {string.Format(Format, playAmount)} ({audience} seats)\n");
        return this;
    }

    public IInvoiceBuilder AddTotalAmount(double totalAmount)
    {
        _parts.Add($"Amount owed is {string.Format(Format, totalAmount)}\n");
        return this;
    }

    public IInvoiceBuilder AddVolumeCredits(string volumeCredits)
    {
        _parts.Add($"You earned {volumeCredits} credits\n");
        return this;
    }

    public string Build()
    {
        return string.Join("", _parts);
    }
}