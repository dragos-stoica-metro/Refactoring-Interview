using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Statements.Formatters;
using Statements.Plays;

namespace Statements.Domain;

public class Statement
{
    private readonly IInvoiceBuilder _builder;
    private readonly List<Play> _plays;

    public Statement(List<Play> plays, IInvoiceBuilder builder)
    {
        _plays = plays;
        _builder = builder;
    }

    public string Generate(Invoice invoice)
    {
        var totalAmount = 0;
        double volumeCredits = 0;

        _builder.AddHeader(invoice.CustomerName);

        foreach (var perf in invoice.Performances)
        {
            var play = _plays.FirstOrDefault(x => x.PlayId == perf.PlayId);
            if (play == null) continue;

            var thisAmount = play.CalculateAmount(perf.Audience);
            volumeCredits += play.CalculateVolumeCredits(perf.Audience);

            _builder.AddPlay(play.Name, thisAmount / 100.0, perf.Audience);
            totalAmount += thisAmount;
        }

        _builder.AddTotalAmount(totalAmount / 100.0);
        _builder.AddVolumeCredits(volumeCredits.ToString(CultureInfo.InvariantCulture));

        return _builder.Build();
    }
}