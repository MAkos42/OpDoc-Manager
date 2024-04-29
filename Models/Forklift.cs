
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.ComponentModel.DataAnnotations;

namespace OpDoc_Manager.Model.Entity
{
    public partial class Forklift
    {
        [Key]
        public string UniqueId { get; set; }
        //Owned
        public GeneralInformation General { get; set; }

        //public OperationalInformation Operation { get; set; }

        //public UserManualInformation UserManual { get; set; }

        //public TechnicalInformation Technical { get; set; }

        //public AdapterInformation Adapter { get; set; }

        //public ServiceDocumentList ServiceDocumentation { get; set; }

        //public PeriodicInspectionInformation PeriodicInspection { get; set; }

        //public ICollection<OperationRecordElement> OperationRecord {  get; set; }

        //public ICollection<ManagerInformation> OpDocManagerRecord { get; set; }

        //public ICollection<ManagerInformation> MaintenanceTechnicianRecord { get; set; }

        //public ICollection<MaintenanceRecordElement> RepairsAndPartReplacements { get; set; }
    }
}
