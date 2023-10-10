namespace PSB_ex6.Checkpoint;

public class TripConcreteBuilder : TripBuilder
{
    private Trip trip = new Trip();

    public override TripBuilder AddCheckpoint(Checkpoint checkpoint)
    {
        trip.AddCheckpoint(checkpoint);
        return this;
    }

    public override Trip Build()
    {
        return trip;
    }
}