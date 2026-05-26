using System;
using System.Collections.Generic;

namespace dicontainer;


using System;
using System.Collections.Generic;
using System.Linq;

public enum ServiceLifetime
{
    Transient,
    Singleton
}

public class ServiceDescriptor
{
    public Type ImplementationType { get; }
    public ServiceLifetime Lifetime { get; }
    public object? Instance { get; set; }

    public ServiceDescriptor(Type implementationType, ServiceLifetime lifetime)
    {
        ImplementationType = implementationType;
        Lifetime = lifetime;
    }
}

public class DIContainer
{
   private readonly Dictionary<Type, ServiceDescriptor> _register = new();

   public DIContainer()
   {
   }


   public void Register<TAbstraction, TImplementation>(
        ServiceLifetime lifetime = ServiceLifetime.Transient)
        where TImplementation : TAbstraction
   {
       _register[typeof(TAbstraction)] =
           new ServiceDescriptor(typeof(TImplementation), lifetime);
   }

   /*public void Register<TInterface, TImplementation>() where TImplementation: TInterface
   {
       _register[typeof(TInterface)] = typeof(TImplementation);
   }*/

   public T Resolve<T>()
   {
       return (T)Resolve(typeof(T));
   }

   private object CreateInstance(Type implementationType)
   {
       var constructor = implementationType
           .GetConstructors()
           .OrderByDescending(c => c.GetParameters().Length)
           .FirstOrDefault();

       if (constructor == null)
       {
           throw new InvalidOperationException(
               $"No public constructor found for {implementationType.Name}");
       }

       var parameters = constructor.GetParameters();

       var dependencies = parameters
           .Select(p => Resolve(p.ParameterType))
           .ToArray();

       var instance = Activator.CreateInstance(implementationType, dependencies);

       if (instance == null)
       {
           throw new InvalidOperationException(
               $"Could not create instance of {implementationType.Name}");
       }

       return instance;
   }

   private object Resolve(Type requestedType, bool forceCreation = false)
   {
       if (!_register.TryGetValue(requestedType, out var descriptor) && forceCreation)
       {
           // Allows resolving concrete classes even if not registered
           if (forceCreation)
           {
               return CreateInstance(requestedType);
           }
           throw new InvalidOperationException(
               $"Type {requestedType.Name} is not registered.");
       }

       if (descriptor.Lifetime == ServiceLifetime.Singleton)
       {
           if (descriptor.Instance == null)
           {
               descriptor.Instance = CreateInstance(descriptor.ImplementationType);
           }

           return descriptor.Instance;
       }

        // Transient: always create a new object
       return CreateInstance(descriptor.ImplementationType);
   }
}


public interface INotificationService
{
    void Send(string message);
}

public class EmailNotificationService : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

public class OrderService
{
    private readonly INotificationService _notificationService;

    public OrderService(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public void PlaceOrder()
    {
        Console.WriteLine("Order placed.");
        _notificationService.Send("Your order was placed.");
    }
}



public class Solution
{
    public static void Main(string[] args)
    {
       Console.WriteLine("DI Container example");
       var di = new DIContainer();

       di.Register<INotificationService, EmailNotificationService>();
       di.Register<OrderService, OrderService>();

       var orderService = di.Resolve<OrderService>();

       orderService.PlaceOrder();
    }
}
