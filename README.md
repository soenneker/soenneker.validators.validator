[![](https://img.shields.io/nuget/v/Soenneker.Validators.Validator.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Validators.Validator/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.validator/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.validators.validator/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Validators.Validator.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Validators.Validator/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.validator/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.validators.validator/actions/workflows/codeql.yml)

# Soenneker.Validators.Validator

Marker and logging base types used by Soenneker validator packages.

## Install

```bash
dotnet add package Soenneker.Validators.Validator
```

## Types

- `IValidator` is an empty marker interface. It does not define a common `Validate` method because individual validators have different inputs, outputs, and async requirements.
- `Validator` is an abstract base class that implements the marker and stores an `ILogger<Validator>` for derived classes.

This package does not register services with dependency injection and is not useful as a standalone validation engine.

## Build a validator

Define the operation on a domain-specific interface:

```csharp
using Soenneker.Validators.Validator.Abstract;

public interface IOrderNumberValidator : IValidator
{
    bool Validate(string? value);
}
```

Then derive from the logging base when shared logger access is useful:

```csharp
using Microsoft.Extensions.Logging;

public sealed class OrderNumberValidator :
    Soenneker.Validators.Validator.Validator,
    IOrderNumberValidator
{
    public OrderNumberValidator(ILogger<OrderNumberValidator> logger)
        : base(logger)
    {
    }

    public bool Validate(string? value)
    {
        bool valid = !string.IsNullOrWhiteSpace(value);

        if (!valid)
            Logger.LogDebug("Order number was missing");

        return valid;
    }
}
```

`ILogger<TCategoryName>` is covariant, so a derived validator's typed logger can be passed to the base constructor. The exposed `Logger` property is typed as `ILogger<Validator>` and has a public setter; avoid replacing it after construction unless the validator explicitly requires mutable logging behavior.

Registration lifetime and disposal belong to each concrete validator package because this base class owns no resources beyond the logger reference.
