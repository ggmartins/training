
# 1. Framework Design

## 1.1 Designing frameworks
What is a framework?
A software framework in computer programming is an abstraction in which common code provides a generic
functionality that can be selectively overridden or specialized by a user's code providing specific functionality.

<img width="553" alt="image" src="https://github.com/user-attachments/assets/17c93102-1197-434e-9b21-da272b094ca7" />

A framework can be a library of code that performs a special task or a much more complicated foundation for your codebase
that handles complicated systems and even renders logic critical for your application to run.

- A framework represents a core pillar of a project's code. It needs to be bug-free.
- Frameworks help remove repetitive tasks and speed up development by providing a foundation for your code base.
- When designing a framework, it's crucial to plan ahead, ensure it is reusable, scalable, bug-free, and easy to implement.
- Good frameworks should be self-contained and easily shareable, with minimal dependencies on other libraries.
- When designing a framework: create a goal and try to find the simplest solution to achieve it. Don't try to reinvent the wheel.

## 1.2 Code Encapsulation

- Encapsulation: Encapsulation is used to hide the values or state of a structured data object inside a class, preventing unauthorized access.
  It simplifies external interactions and protects the data within your framework.
- Scope Management: Define strict scope for your framework's APIs. Public methods should be externally facing,
  while internal code should be protected. Use virtual for extendable code and read-only, static, or sealed for final code.
  (Avoid private scope, use Protected Virtual Scope instead).
- Data Protection: Avoid directly manipulating data passed into methods.
  Make a copy of the data or use the ref argument to clearly state that properties will be manipulated.
- Performance Considerations: While encapsulation helps isolate your framework's code, be mindful of potential performance issues
  and document any trade-offs.

## 1.3 Design Interfaces

Modularity through Interfaces: Interfaces help create a modular framework by providing clean, public-facing APIs that can be
easily extended and enhanced.
Extending Functionality: By implementing these interfaces in concrete classes, you can extend the framework's functionality while maintaining clean
and organized code. The example of MyClass shows how to implement both ISave and ILoad interfaces and add custom methods.

```csharp
public interface ISave
{
   void Save(string s);
}
public interface ILoad
{
   string Load();
}

public class MyClass: ISave, ILoad
{
   public void CustomMethod()
   {
      //Custom Logic
   }
   public void Save(string s)
   {
   }
   public string Load()
   {
   }
}
```

```csharp

public interface IMyClassIO: ISave, ILoad
{
   void CustomMethod()
   {
      //Custom Logic
   }
}

public class MyClass: IMyClassIO
{
   ... //same as MyClass
}
```
## 1.4 Modular Classes
While frameworks are generally designed to solve a specific task or collection of tasks, you should try to capture more edge cases.
What are the questions you should try to answer early on in a framework's development process? Does the framework do what others need?
What happens when someone needs to do X, Y, and Z, and how do you plan to account for it? Can it scale? Can your framework scale to
the needs of the users, or are you building a tool that is not flexible? And finally, can it be extended? Can users extend what you've done,
and build on top of it easily? Here are some tips for building modular classes. 

### 1.4.1 Use interfaces.
Does your class implement any type of interface? Interfaces allow you to interchange with other classes. So if a developer needs to create a
custom class with its own logic, but still work within your framework, they can adopt the interface your framework requires.
### 1.4.2 Do your classes support extending?
Is the class sealed, or do you expect developers to extend it? Are you using virtual in your public and protected method scopes? 
### 1.4.3 Do you have abstract classes?
Are you creating abstract classes and base classes as a layer of foundation, or is the
class a concrete implementation with no inheritance? You should be building basic classes that other classes in your framework extend on, so if 
developers need to create new classes, they can use the abstract or the base class as a starting point instead of having to implement all of the
business logic from scratch by implementing an interface.
### 1.4.4 Do you have utilities?
What kind of utility classes do you provide? Are they singletons or can they be extended?
### 1.4.5 Do you have Primitive classes?
What are the primitive classes of your framework? Are they enough, and can they be used outside of the framework,
or are they closely tied to the intended use case? What are the basic classes of data that your framework requires,
and are these useful enough for developers as is, or should they have to provide their own primitive classes?
### 1.4.6 Sharing the code
Are you sharing the code of your framework, and do you intend others to extend it beyond its original design? Or would you rather keep it
private? Take some time to answer these questions and refer back to them while you architect your framework's code. I find that just like
creating a business plan for a company, you should have a mission statement for the framework itself. This mission statement should outline the
intended use of the framework, and what you expect of it over time. Define what you think makes the framework successful, and what are the 
things that your framework is trying to solve? As you build out the code base and add functionality, check your mission statement and see that
you're staying true to your vision for the framework.

# 2. Extending Frameworks

## 2.1 Create indepedent modules

- Understand the Use Cases: Clearly define what problems your framework solves to ensure its focus is narrow and useful.
- Identify Gaps: Recognize what your framework doesn't solve and how developers might address these gaps.
- Design for Extensibility: Use virtual methods, interfaces, and base/abstract classes to allow others to extend and customize your framework.
- Self-Contained Modules: Ensure modules are self-contained and clean up dependencies to make them portable and reusable.
- Continuous Improvement: Use your own framework in projects to identify and fix bugs and missing features.
- Some of the best frameworks were pulled out from existing projects
- Clean dependencies, make it self contained and reintroduce the framework back into the project
- Git submodules
- Independent to be portable

## 2.2 Enforce an architecture pattern

- Create a consistent API and design pattern
- <b>Consistent</b> API, Classes and Interfaces
- Action Design pattern
  - Extend the Abstract Action Class
  - Override the Name Property
  - Add their own logic to the overridden Execute method
 
```csharp
public abstract class Action
{
   public virtual string Name => "";
   public virtual void Execute(string[] args)
   {
      throw new Exception("Nothing to execute")
   }
}
```
Now becomes =>
```csharp
public interface IAction
{
   string Name => "";
   void Execute(string[] args)
}

```

# 3. Hosting Code

## 3.1 Share Framework
- Clean API Architecture: Ensure that all public-facing methods are easy to understand, use, and implement in other developers' codebases.
- Documentation: Thoroughly document your APIs with examples to make them easy to use.
- Clear Functionality: Clearly define what your framework does, the problems it solves, and how it improves other developers' codebases.
- Sharing Options: Share your framework through dynamic link libraries (DLLs), NuGet packages, or hosting it online on platforms like GitHub.
- Build more than one framework as needed, limit the dependencies, don't create a monster that tries to solve everything.
- Shared Project (Visual Studio)
- NuGet
## 3.2 Hosting framework
- Github, Gitlab, Bitbucket
- Track bugs
- See progress
- Allow contributions
- opensource.org
## 3.3 Documenting Framework
- Use /// (create auto-summary)
- Importance of Documentation: Proper documentation is crucial for the adoption and usability of your framework.
  Well-documented public APIs are essential.
- XML-style Commenting: Use XML-style comments in Visual Studio by typing three forward slashes above a class or method.
  This generates an XML template for documentation.
- Benefits of Documentation: Documenting code helps other developers understand and use your framework,
  and it also serves as a reminder for yourself about the design and functionality of your code.
## 3.4 Setting up github
- .github folder with
- ISSUE_TEMPLATE -> bug_report.md
- CODE_OF_CONDUCT.md
- CONTRIBUTING.md
# 4. Continuous Integration
## 4.1 What is CI?
- Automation: CI automates the building, testing, and deployment of your code, ensuring consistency and reducing human error.
- Integration with GitHub: CI can be integrated with GitHub to trigger builds and tests automatically when code is pushed or checked in.
- Tools and Systems: There are several CI tools available, such as Travis CI, Azure Pipelines, and GitHub Actions,
which helps in creating custom workflows and ensuring code stability.
- Custom CI: Nodejs gulp
## 4.2 Custom build scripts
- `dotnet publish -r osx-x64 -p:PublishSingleFile=true -p:SelfContained=true -p:PublishTrimmed=true -o ./Release/dist`
- `dotnet pack` (for NuGet)
- gulp script (nodejs)
- `npm init`
- `npm i -s gulp` and `npm -i -s gulp`
- `gulpfile.js`
```javascript
const gulp = require("gulp")
const shell = require("gulp-shell")

gulp.task(
  'default',
  gulp.series(
     [
       shell.task("dotnet pack -o ./Release/")
     ]
  )
)
```
## 4.3 Using Github Actions
- Actions live inside `.github/workflows/`
- `.github/workflows/main.yaml`
```yaml
name: Any Name
on:
  push:
     branches:
        - main
jobs:
  create-release:
    name: main release
    runs-on: ubuntu-latest
  steps:
    - uses: actions/checkout@v2
    - uses: actions/setup-dotnet@v1
      with:
         dotnet-version: 8.0
    - uses: actions/node@v1
    - run: |
       npm install
       gulp
    - uses: actions/upload-artefacts@v3
      with:
        name: mycoolname
        path: ./Releases
```
    
