using PrimeTech.Interview.Business.SharedKernel;

namespace PrimeTech.Interview.Business.Commands.Commands
{
    public class UpdateCompanyCommand : CommandBase
    {
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
