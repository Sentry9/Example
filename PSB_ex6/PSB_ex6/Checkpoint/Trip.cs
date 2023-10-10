namespace PSB_ex6.Checkpoint;

public class Trip
{
    private List<Checkpoint> checkpoints = new List<Checkpoint>();

    public void AddCheckpoint(Checkpoint checkpoint)
    {
        checkpoints.Add(checkpoint);
    }

    public List<Checkpoint> GetCheckpoints()
    {
        return checkpoints;
    }

    public double GetPenalty()
    {
        double totalPenalty = 0.0;
        foreach (var checkpoint in checkpoints)
        {
            totalPenalty += checkpoint.Penalty ?? 0.0;
        }

        return totalPenalty;
    }
    public void PrintCheckpointsAndPenalty()
    {
        foreach (var checkpoint in checkpoints)
        {
            Console.WriteLine($"Имя: {checkpoint.Name}");
            Console.WriteLine($"Координаты: ({checkpoint.Latitude}, {checkpoint.Longitude})");
            if (checkpoint.Penalty == null)
            {
                Console.WriteLine("Штраф: незачёт СУ");
            }
            else
            {
                Console.WriteLine($"Штраф: {checkpoint.Penalty} ч");
            }
        }

        var penalty = GetPenalty();
        Console.WriteLine($"Суммарный штраф: {penalty} ч");
    }
}