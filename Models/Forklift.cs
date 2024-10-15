using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        [Key]
        public Guid UniqueId { get; set; }

        public GeneralInformation General { get; set; }

        public OperatorInformation Operator { get; set; }

        public UserManualInformation UserManual { get; set; }

        public OperationType Technical { get; set; }

        [ForeignKey("TechnicalInformation")]
        private Guid forkliftTypeId { get; set; }

        //public AdapterInformation Adapter { get; set; }

        //public ServiceDocumentList ServiceDocumentation { get; set; }

        //public PeriodicInspectionInformation PeriodicInspection { get; set; }

        //public ICollection<OperationRecordElement> OperationRecord {  get; set; }

        //public ICollection<ManagerInformation> OpDocManagerRecord { get; set; }

        //public ICollection<ManagerInformation> MaintenanceTechnicianRecord { get; set; }

        //public ICollection<MaintenanceRecordElement> RepairsAndPartReplacements { get; set; }
    }
}
