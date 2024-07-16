using PrimeTech.Interview.Business.SharedKernel;

namespace PrimeTech.Interview.Business.Commands.Commands
{
    public class CreateCompanyCommand : CommandBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
