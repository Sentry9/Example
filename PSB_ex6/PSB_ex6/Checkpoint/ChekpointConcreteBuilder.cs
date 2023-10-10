namespace PSB_ex6.Checkpoint;

public class CheckpointConcreteBuilder : CheckpointBuilder
{
    private Checkpoint _checkpoint = new();

    public override CheckpointBuilder SetName(string name)
    {
        _checkpoint.Name = name;
        return this;
    }

    public override CheckpointBuilder SetCoordinates(double latitude, double longitude)
    {
        if (latitude < -90 || latitude > 90)
        {
            throw new ArgumentOutOfRangeException(nameof(latitude), "Широта должна быть в диапазоне от -90 до 90.");
        }

        if (longitude < -180 || longitude > 180)
        {
            throw new ArgumentOutOfRangeException(nameof(longitude), "Долгота должна быть в диапазоне от -180 до 180.");
        }

        _checkpoint.Latitude = latitude;
        _checkpoint.Longitude = longitude;
        return this;
    }

    public override CheckpointBuilder SetPenalty(double? penalty)
    {
        _checkpoint.Penalty = penalty;
        return this;
    }

    public override Checkpoint Build()
    {
        return _checkpoint;
    }
}