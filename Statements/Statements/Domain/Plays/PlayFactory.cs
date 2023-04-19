using System;
using Statements.Plays;

namespace Statements.Domain.Plays;

public static class PlayFactory
{
    public static Play Create(string playId, string name, PlayTypeEnum type)
    {
        return type switch
        {
            PlayTypeEnum.Tragedy => new TragedyPlay(playId, name),
            PlayTypeEnum.Comedy => new ComedyPlay(playId, name),
            _ => throw new ArgumentException($"Unknown play type: {type}")
        };
    }
}