namespace NeighborhoodAPI.Models
{
    public class Neighborhood
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public double SafetyScore { get; set; }
        public double SchoolScore { get; set; }
        public double TransportScore { get; set; }
        public double AmenitiesScore { get; set; }
        public double CommunityScore { get; set; }

        // Automatically calculates TotalScore when accessed
        public double TotalScore =>
            (SafetyScore * 0.3 +
             SchoolScore * 0.25 +
             TransportScore * 0.2 +
             AmenitiesScore * 0.15 +
             CommunityScore * 0.1);
    }
}
