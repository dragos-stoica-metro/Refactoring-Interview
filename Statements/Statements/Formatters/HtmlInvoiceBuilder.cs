using System.Collections.Generic;

namespace Statements.Formatters;

//This is just an example for another type of formatter
public class HtmlInvoiceBuilder : IInvoiceBuilder
{
    private const string Format = "{0:C}";
    private readonly List<string> _parts = new();

    public IInvoiceBuilder AddHeader(string customerName)
    {
        _parts.Add($"<h1>Statement for {customerName}</h1>");
        return this;
    }

    public IInvoiceBuilder AddPlay(string playName, double playAmount, int audience)
    {
        _parts.Add($"<p>{playName}: {string.Format(Format, playAmount)} ({audience} seats)</p>");
        return this;
    }

    public IInvoiceBuilder AddTotalAmount(double totalAmount)
    {
        _parts.Add($"Amount owed is {string.Format(Format, totalAmount)}\n");
        return this;
    }

    public IInvoiceBuilder AddVolumeCredits(string volumeCredits)
    {
        _parts.Add($"<p>You earned {volumeCredits} credits</p>");
        return this;
    }

    public string Build()
    {
        return string.Join("", _parts);
    }
}