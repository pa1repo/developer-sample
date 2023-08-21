using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private Dictionary<Type, Type> containerBindings = new Dictionary<Type, Type>();
        /// <summary>
        /// Bind to this container an interfacetype and an implementation for it
        /// </summary>
        /// <param name="interfaceType"></param>
        /// <param name="implementationType"></param>
        /// <exception cref="InvalidCastException">Throws invalid cast if implementationType does not inherit from interfaceType </exception>
        public void Bind(Type interfaceType, Type implementationType)
        {
            if (!interfaceType.IsAssignableFrom(implementationType))
                throw new InvalidCastException($@"Type:{implementationType.FullName} does not implement {interfaceType.FullName}");
            containerBindings[interfaceType] = implementationType;
            // if(containerBindings.ContainsKey(interfaceType))
            //  containerBindings[interfaceType] = implementationType;
            // containerBindings.Add(interfaceType, implementationType);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException">Returned when bind is not called prior to get</exception>
        /// <exception cref="InvalidCastException">implementationType does not implement interfaceType </exception>
        public T Get<T>()
        {
            Type getType = typeof(T);
            Type containerType;
            containerBindings.TryGetValue(getType, out containerType);
            if (containerType == null)
                throw new KeyNotFoundException($@"Could not find Type:{getType.FullName} in container; make sure to call .Bind() first");
            if (!getType.IsAssignableFrom(containerType))
                throw new InvalidCastException($@"Type:{containerType.FullName} does not implement {getType.FullName}");
            return (T)Activator.CreateInstance(containerType);

        }
    }
}