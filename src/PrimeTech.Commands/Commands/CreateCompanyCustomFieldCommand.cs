using PrimeTech.Interview.Business.SharedKernel;

namespace PrimeTech.Interview.Business.Commands.Commands
{
    public class CreateCompanyCustomFieldCommand : CommandBase
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public int CompanyID { get; set; }
    }
}
