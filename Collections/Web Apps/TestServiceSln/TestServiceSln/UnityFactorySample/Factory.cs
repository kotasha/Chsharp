using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace UnityFactorySample
{
    public class Factory
    {
        //IUnityContainer container = new UnityContainer();
        
        public static IPerson CreateInstance()
        {
            try
            {
                IUnityContainer _localContainer = new UnityContainer();
                IPerson _person = _localContainer.Resolve<Player>();
                return _person;
            }
            catch (Exception obj)
            {
                throw obj;
            }
        }
        
    }
}
