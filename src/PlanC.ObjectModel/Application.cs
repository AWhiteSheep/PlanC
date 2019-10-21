using PlanC.DataAccessModel;
using System;
using System.ComponentModel;

namespace PlanC.ObjectModel
{
    public class Application
    {
        private Type _dataContextType;
        private IDataContext _dataContext;
        internal IDataContext DataContext
        {
            get
            {
                if (_dataContext == null)
                {
                    CreateDataContext();
                }
                return _dataContext;
            }
        }

        public Application(Type dataContextType)
        {
            if (!typeof(IDataContext).IsAssignableFrom(dataContextType))
            {
                throw new ArgumentException(
                    $"The type specified must be assignable to {typeof(IDataContext)}.",
                    nameof(dataContextType));
            }
            _dataContextType = dataContextType ?? typeof(DefaultDataContext);
        }

        private IDataContext CreateDataContext()
        {
            return (IDataContext)TypeDescriptor.CreateInstance(null, _dataContextType, null, null);
        }
    }
}
