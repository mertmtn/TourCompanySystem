using Entities.Abstract;

namespace Entities.DTO
{
    public class PermissionDTO:IDTO
    {
        public int PermissionId { get; set; }
        public string EmployeeFullName { get; set; }
        public string StatusName { get; set; }
        public string PermissionType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? UsedDays { get; set; }
        public int? UsedHours { get; set; }
        public string? Description { get; set; } 
    }
}
