namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class ServiceDocumentList
        {
            public DocumentPresenceRecord ComplianceCertificate { get; set; }
            public DocumentPresenceRecord ComplianceStatement { get; set; }
            public DocumentPresenceRecord UserManual { get; set; }
            public DocumentPresenceRecord  InspectionReport { get; set; }
            public DocumentPresenceRecord? NoisePollutionReport { get; set; }
            public DocumentPresenceRecord PeriodicInspectiocReport { get; set; }
            public DocumentPresenceRecord? FlexibleTractionElementReport { get; set; }
            public DocumentPresenceRecord ForkliftManual {  get; set; }
            public DocumentPresenceRecord ForkliftLogbook { get; set; }
            public DocumentPresenceRecord? OperationPermit { get; set; }
            public DocumentPresenceRecord WorkSafetyRecord { get; set; }
            public DocumentPresenceRecord StartOfServiceRecord { get; set; }
            public DocumentPresenceRecord OperationalHours {  get; set; }
            public DocumentPresenceRecord? Other {  get; set; }
        }
    }
}
