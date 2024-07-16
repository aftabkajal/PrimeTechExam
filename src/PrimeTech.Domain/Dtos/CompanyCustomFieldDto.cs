using System.Collections.Generic;

namespace PrimeTech.Interview.Business.Domain.Dtos
{
    public record CompanyCustomFieldDtos
    {
        public int CompanyID { get; set; }
        public List<CompanyCustomFieldDto> CustomFields { get; set; }
    }
    public record CompanyCustomFieldDto
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
    }
}
