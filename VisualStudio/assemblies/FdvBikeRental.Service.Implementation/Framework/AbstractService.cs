using FdvBikeRental.DataAccess.Api.Framework;
using System.Web.Http;
using FdvBikeRental.Service.Api.Framework;
using FdvBikeRental.Service.Implementation.Manager;

namespace FdvBikeRental.Service.Implementation.Framework
{
    /// <summary>
    /// Abstract Service
    /// </summary>
    /// <typeparam name="TDataAccessInterface"></typeparam>
    public abstract class AbstractService<TDataAccessInterface> : ApiController, IAbstractService where TDataAccessInterface : IAbstractDataAccess
    {

        /// <summary>
        /// 
        /// </summary>
        private TDataAccessInterface _dao;

        /// <summary>
        /// 
        /// </summary>
        protected TDataAccessInterface Dao
        {
            get
            {
                if (_dao == null)
                {
                    _dao = ServiceManager.GetService<TDataAccessInterface>();
                }
                return _dao;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetService<T>() where T : IAbstractDataAccess
        {
            T service = ServiceManager.GetService<T>();

            return service;
        }

    }
}

