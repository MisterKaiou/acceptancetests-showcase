# Showcasing Acceptance Tests With Specflow

## The questions

### What is [Specflow](https://docs.specflow.org/projects/specflow/en/latest/)

SpecFlow is a test automation solution for .NET built upon the BDD paradigm. Use
SpecFlow to define, manage and automatically execute human-readable acceptance tests
in .NET projects (Full Framework and .NET Core). 
SpecFlow tests are written using Gherkin, which allows you to write test cases 
using natural languages. SpecFlow uses the official Gherkin parser, which supports
over 70 languages. These tests are then tied to your application code using
so-called bindings, allowing you to execute the tests using the testing framework 
of your choice. You can also execute your tests using SpecFlow’s own dedicated test 
runner, SpecFlow+ Runner.

### What is [Cucumber](https://cucumber.io/docs/guides/overview/)
Cucumber reads executable specifications written in plain text and validates that 
the software does what those specifications say. The specifications consists of
multiple examples, or scenarios. For example:

```Scenario: Breaker guesses a word 
Given the Maker has chosen a word
When the Breaker makes a guess
Then the Maker is asked to score
```
Each scenario is a list of steps for Cucumber to work through. Cucumber verifies 
that the software conforms with the specification and generates a report indicating
✅ success or ❌ failure for each scenario.

In order for Cucumber to understand the scenarios, they must follow some basic 
syntax rules, called Gherkin.

### What is [Gherkin](https://cucumber.io/docs/guides/overview/#what-is-gherkin)
Gherkin is a set of grammar rules that makes plain text structured enough for Cucumber to understand. The scenario above is written in Gherkin.

Gherkin serves multiple purposes:

- Unambiguous executable specification
- Automated testing using Cucumber
- Document how the system actually behaves
- Single source of Truth

The Cucumber grammar exists in different flavours for many spoken languages so that
your team can use the keywords in your own language.

Gherkin documents are stored in `.feature` text files and are typically versioned in
source control alongside the software.

See the [Gherkin reference](https://cucumber.io/docs/gherkin/) for more details.

### What is [BDD](https://cucumber.io/docs/bdd/)
Behaviour-Driven Development (BDD) is the software development process that Cucumber
was built to support.

There’s much more to BDD than just using Cucumber.

BDD is a way for software teams to work that closes the gap between business people
and technical people by:

- Encouraging collaboration across roles to build shared understanding of the problem to be solved
- Working in rapid, small iterations to increase feedback and the flow of value
- Producing system documentation that is automatically checked against the system’s behaviour

We do this by focusing collaborative work around concrete, real-world examples that
illustrate how we want the system to behave. We use those examples to guide us from
concept through to implementation, in a process of continuous collaboration.

#### [Documentation used](https://cucumber.io/docs/cucumber/)

## What was used

### [NUnit](https://nunit.org/)
NUnit is a unit-testing framework for all .Net languages. Initially ported from 
JUnit, the current production release, version 3, has been completely rewritten with
many new features and support for a wide range of .NET platforms. Specflow offers
support for NUnit as the test framework.

### [FluentAssertions](https://fluentassertions.com/introduction)
Fluent Assertions is a set of .NET extension methods that allow you to more naturally
specify the expected outcome of a TDD or BDD-style unit test. This enables a simple
intuitive syntax that all starts with the following `using` statement.

It's a very extensive set of extension methods that allow you to more naturally 
specify the expected outcome of a TDD or BDD-style unit tests. Targets .NET
Framework 4.5 and 4.7, as well as .NET Core 2.0, .NET Core 2.1, .NET Core 3.0,
.NET Standard 1.3, 1.6 2.0 and 2.1.
