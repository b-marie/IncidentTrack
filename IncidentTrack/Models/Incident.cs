using System;

namespace IncidentTrack.Models
{
    public class Incident
    {
        public int Id { get; set; }
        public ApplicationUser ReportingEmployee { get; set; }
        public DateTime WhenIncidentOccurred { get; set; }
        public Location Location { get; set; }
        public Department Department { get; set; }
        public AffectedBodyPart AffectedBodyPart { get; set; }
        public InjuryType InjuryType { get; set; }
        public string IncidentDescription { get; set; }
        public string IncidentResponse { get; set; }
        public string InitialRecommendations { get; set; }
        public ApplicationUser Witness { get; set; }

    }
}