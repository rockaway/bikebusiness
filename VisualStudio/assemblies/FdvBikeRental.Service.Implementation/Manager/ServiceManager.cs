using System;
using System.Collections.Generic;
using FdvBikeRental.DataAccess.Implementation.Rental;

namespace FdvBikeRental.Service.Implementation.Manager
{
    /// <summary>
    /// Service Manager
    /// </summary>
    public class ServiceManager
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private static readonly object ObjLock = new object();

        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<Type, object> Services = new Dictionary<Type, object>();

        #endregion Fields

        #region Public function

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>()
        {
            Type type = typeof(T);

            object o;
            lock (ObjLock)
            {
                if (Services.TryGetValue(type, out o))
                    return (T)o;
            }

            lock (ObjLock)
            {
                object serviceObject = CreateServiceObject(type);
                Services.Add(type, serviceObject);
                return (T)Services[type];
            }
        }

        #endregion Public function

        #region Private function

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static object CreateServiceObject(Type type)
        {
            switch (type.Name)
            {
                case "IRentalDataAccess":
                    return new RentalDataAccess();
            }

            throw new Exception("Interface not found.");
        }

        #endregion Private function
    }
}