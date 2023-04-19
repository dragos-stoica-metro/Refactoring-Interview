using System;
using Statements.Plays;

namespace Statements.Domain.Plays;

public class TragedyPlay : Play
{
    public TragedyPlay(string playId, string name) : base(playId, name)
    {
    }

    public override int CalculateAmount(int audience)
    {
        var amount = 40000;
        if (audience > 30) amount += 1000 * (audience - 30);

        return amount;
    }

    public override double CalculateVolumeCredits(int audience)
    {
        return Math.Max(audience - 30, 0);
    }
}