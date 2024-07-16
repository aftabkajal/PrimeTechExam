using System;

namespace PrimeTech.Interview.Business.SharedKernel;
public abstract class QueryBase
{
    public string RequestId { get; set; } = Guid.NewGuid().ToString();
}