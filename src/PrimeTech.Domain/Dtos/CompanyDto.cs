namespace PrimeTech.Interview.Business.Domain.Dtos;

public record CompanyDto
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}

