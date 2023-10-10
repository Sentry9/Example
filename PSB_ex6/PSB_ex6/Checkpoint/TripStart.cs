namespace PSB_ex6.Checkpoint;

public class TripStart
{
    public static void Launch()
    {
        var point1 = new CheckpointConcreteBuilder()
            .SetName("Point 1")
            .SetCoordinates(50.0, 30.0)
            .SetPenalty(2.5)
            .Build();

        var point2 = new CheckpointConcreteBuilder()
            .SetName("Point 2")
            .SetCoordinates(55.0, 35.0)
            .SetPenalty(3.0)
            .Build();

        var point3 = new CheckpointConcreteBuilder()
            .SetName("Point 3")
            .SetCoordinates(60.0, 40.0)
            .Build();

        var trip = new TripConcreteBuilder()
            .AddCheckpoint(point1)
            .AddCheckpoint(point2)
            .AddCheckpoint(point3)
            .Build();

        var checkPoints = trip.GetCheckpoints();
        var penalty = trip.GetPenalty();

        trip.PrintCheckpointsAndPenalty();
    }
}