using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class BusinessLayer
    {
        public static T CreateObject<T>(ObjectType objtype) where T : IBusinessLayer
        {
            var business = default(IBusinessLayer);

            switch (objtype)
            {
                //case ObjectType.Books:
                    
            }
            return (T)business;
        }
    }
}
