using PrimeTech.Interview.Business.SharedKernel;

namespace PrimeTech.Interview.Business.Domain.Entities;

public class Company : EntityBase
{
    public string Name { get; set; }
    public string Address { get; set; }
}

