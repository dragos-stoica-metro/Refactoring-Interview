namespace Statements.Plays;

public abstract class Play
{
    protected Play(string playId, string name)
    {
        PlayId = playId;
        Name = name;
    }

    public string PlayId { get; }
    public string Name { get; }

    public abstract int CalculateAmount(int audience);
    public abstract double CalculateVolumeCredits(int audience);
}