using System.ComponentModel.DataAnnotations;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        [Key]
        public Guid UniqueId { get; set; }

        public GeneralInformation General { get; set; }

        public OperatorInformation Operator { get; set; }

        public UserManualInformation UserManual { get; set; }

        public AdapterInformation Adapter { get; set; }

        //public PeriodicInspectionInformation PeriodicInspection { get; set; }

        //public ICollection<OperationRecordElement> OperationRecord {  get; set; }

        //public ICollection<ManagerInformation> DocumentManagerRecord { get; set; }

        //public ICollection<ManagerInformation> MaintenanceTechnicianRecord { get; set; }

        //public ICollection<MaintenanceRecordElement> RepairsAndPartReplacements { get; set; }
    }
}
