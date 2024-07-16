using System;

namespace PrimeTech.Interview.Business.SharedKernel;

public abstract class EntityBase
{
    public int Id { get; set; }
    public DateTime? CreatedAt {  get; set; }
    public DateTime? UpdatedAt { get; set; }
}
