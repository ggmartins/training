
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

## 1.2 Conde encapsulation

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
