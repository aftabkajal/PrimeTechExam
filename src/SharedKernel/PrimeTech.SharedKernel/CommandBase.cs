using System;

namespace PrimeTech.Interview.Business.SharedKernel;
public abstract class CommandBase
{
    public string RequestId { get; set; } = Guid.NewGuid().ToString();
}
