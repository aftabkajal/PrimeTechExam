using PrimeTech.Interview.Business.SharedKernel;

namespace PrimeTech.Interview.Business.Commands.Commands
{
    public class DeleteCompanyCommand : CommandBase
    {
        public int CompanyID { get; set; }
    }
}
