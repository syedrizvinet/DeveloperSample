using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> bindings = new Dictionary<Type, Type>();

        public void Bind(Type interfaceType, Type implementationType)
        {
            if (interfaceType == null)
            {
                throw new ArgumentNullException(nameof(interfaceType));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException("The provided type must be an interface.", nameof(interfaceType));
            }

            bindings[interfaceType] = implementationType;
        }

        public T Get<T>()
        {
            if (bindings.TryGetValue(typeof(T), out var implementationType))
            {
                return (T)Activator.CreateInstance(implementationType);
            }

            throw new InvalidOperationException($"No binding found for interface {typeof(T)}.");
        }
    }
}