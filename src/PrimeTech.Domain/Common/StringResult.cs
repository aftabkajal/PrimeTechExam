using FluentValidation.Results;

namespace PrimeTech.Interview.Business.Domain.Common;

public class StringResult
{
    private readonly object result;
    private readonly int statusCode;

    public StringResult(object result)
    {
        this.result = result;
        statusCode = 0;
    }


    public StringResult(ValidationResult validationResult)
    {
        result = validationResult;
        statusCode = 1;
    }

    public StringResult(string property, string error)
    {
        result = new ValidationResult(new[] { new ValidationFailure(property, error) });

        statusCode = 1;
    }

    public object GetResponse()
    {
        if (statusCode.Equals(0))
        {
            return result;
        }

        return new
        {
            Result = string.Empty,
            Errors = result,
            StatusCode = 1
        };
    }
}

