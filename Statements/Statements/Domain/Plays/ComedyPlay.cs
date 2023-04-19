using System;
using Statements.Plays;

namespace Statements.Domain.Plays;

public class ComedyPlay : Play
{
    public ComedyPlay(string playId, string name) : base(playId, name)
    {
    }

    public override int CalculateAmount(int audience)
    {
        var amount = 30000;
        if (audience > 20) amount += 10000 + 500 * (audience - 20);

        amount += 300 * audience;
        return amount;
    }

    public override double CalculateVolumeCredits(int audience)
    {
        return Math.Max(audience - 30, 0) + Math.Floor(audience / 5.0);
    }
}