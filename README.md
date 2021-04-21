# DotNotStandard.Validation
This repo contains validation utilities for use in .NET applications. This includes DataAnnotations rules for validation of strings against predefined, allowed sets of characters, as well as disallowing specifically blocked combinations of characters. In other words, we have the combination of allowed and disallowed sets, for the most effective protection.

## Overview

The core of DotNotStandard.Validation includes a data annotations attribute that offers validation against validation rules identified by key. Separate classes are used to load validation rules into the subsystem, using a repository pattern.

There are no repositories in the core package; all implementations are outside of the core package. Initially, the only implementation being made widely available is the in-memory repository, in the package DotNotStandard.Validation.Repositories.InMemoryRepository. If you wish to use this implementation then you need to add a reference to this additional package, and then call the AddValidationInMemoryRepositories() extension method to have it register itself for use.

Consumers of DotNotStandard.Validation are free to make their own repository implementations to suit their own needs. Repositories are loaded through dependency injection, so any consumer will be able to write a repository and register it into the DI container, from where the validation subsystem can load it at will.

Reasons to create your own implementations of repositories include:

1. If you don't like the rules we have defined.
2. If you want additional rules that are not included in the original set.
3. If you would like to load validation rule data from a database.

Validation rules naturally form a part of the protection of your system. As such, it is important that they are maintainable, and that any fixes can quickly be redeployed, so that any loopholes can quickly be closed. Loading validation information from a database is a good way to achieve this, as the database can act as a single point of truth for many applications. However, this requires infrastructure setup, and this is often considered beyond the reach of many people who are consuming a package for the first time - the infrasstructure dependency makes it too onerous.

## Getting Started
The following is a summary of the steps required to make use of this component.

1. Add a reference to the core package.
2. Add a reference to a repository implementation, such as DotNotStandard.Validation.Repositories.InMemoryRepository.
3. In your code, import the namespace DotNotStandard.Validation.Core.
4. Register the repository that will be used to load data. For example, in Startup.cs add:

    `services.AddValidationInMemoryRepositories();`

4. Annotate the property to be validated with the [CharacterSet("RuleName")] attribute, specifying the key of the appropriate rule.
5. The BuiltInRules class exposes a set of constants of common rule names, to avoid the need for magic strings.

Here is a typical property definition for a validated property:

    [Required]
    [MaxLength(100)]
    [CharacterSet(BuiltInRules.CharacterSet.LatinAlphanumeric)]  
    public string Name {get; set;}

Note that the character sets against which validation can be applied are not limited by the list of constants defined on the BuiltInRules class. The property on the attribute is of type string, and any string can be passed, as long as the repository exposes data for that rule. Consider creating your own class exposing additional constants for your own, custom rules, if you want to add more rules.

For example, create a static class called MyRules:

    public static class MyRules
    {
        public const string CapitalA = "MyRules.CapitalA";
    }

Now, make use of the constants to request validation against a rule of that name:

    [CharacterSet(MyRules.CapitalA)]  
    public string Name {get; set;}

Remember that the repository implementation must return a rule for this key, in this case the key is the contents of the string constant: "MyRules.CapitalA".