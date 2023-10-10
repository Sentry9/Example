namespace PSB_ex6.Checkpoint;

public abstract class TripBuilder
{
    public abstract TripBuilder AddCheckpoint(Checkpoint checkpoint);
    public abstract Trip Build();
}