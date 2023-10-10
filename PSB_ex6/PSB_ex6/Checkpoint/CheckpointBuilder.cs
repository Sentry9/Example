namespace PSB_ex6.Checkpoint;

public abstract class CheckpointBuilder
{
    public abstract CheckpointBuilder SetName(string name);
    public abstract CheckpointBuilder SetCoordinates(double latitude, double longitude);
    public abstract CheckpointBuilder SetPenalty(double? penalty);
    public abstract Checkpoint Build();
}