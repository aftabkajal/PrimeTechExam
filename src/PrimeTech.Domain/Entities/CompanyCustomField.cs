using PrimeTech.Interview.Business.SharedKernel;

namespace PrimeTech.Interview.Business.Domain.Entities
{
    public class CompanyCustomField : EntityBase
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public int CompanyID { get; set; }
    }
}
