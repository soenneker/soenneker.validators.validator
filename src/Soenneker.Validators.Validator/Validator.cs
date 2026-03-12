using Microsoft.Extensions.Logging;
using Soenneker.Validators.Validator.Abstract;

namespace Soenneker.Validators.Validator;

///<inheritdoc cref="IValidator"/>
public abstract class Validator : IValidator
{
    public ILogger<Validator> Logger { get; set; }

    protected Validator(ILogger<Validator> logger)
    {
        Logger = logger;
    }
}