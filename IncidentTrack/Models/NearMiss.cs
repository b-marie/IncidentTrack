using System;

namespace IncidentTrack.Models
{
    public class NearMiss
    {

        public int Id { get; set; }
        public ApplicationUser ReportingEmployee { get; set; }
        public DateTime WhenNearMissOccurred { get; set; }
        public Location Location { get; set; }
        public Department Department { get; set; }
        public AffectedBodyPart PotentialAffectedBodyPart { get; set; }
        public InjuryType PotentialInjuryType { get; set; }
        public string NearMissDescription { get; set; }
        public string NearMissResponse { get; set; }
        public string NearMissRecommendations { get; set; }
        public ApplicationUser Witness { get; set; }
    }
}