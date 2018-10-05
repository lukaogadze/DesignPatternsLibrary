using System;
using System.Collections.Generic;
using System.Reflection;
using Factory2.Autos;

namespace Factory2
{
    /// <summary>
    /// A simple auto factory that creates various types of automobiles
    /// based on a key for Type lookup
    /// </summary>
    public class AutoFactory
    {
        Dictionary<string, Type> autos;

        public AutoFactory()
        {
            LoadTypesICanReturn();
        }

        public IAuto CreateInstance(string carName)
        {
            Type t = GetTypeToCreate(carName);

            if(t == null)
                return new NullAuto();

            return Activator.CreateInstance(t) as IAuto;
        }

        Type GetTypeToCreate(string carName)
        {
            foreach (var auto in autos)
            {
                if (auto.Key.Contains(carName))
                {
                    return autos[auto.Key];
                }
            }

            return null;
        }

        void LoadTypesICanReturn()
        {
            autos = new Dictionary<string, Type>();

            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterface(typeof(IAuto).ToString()) != null)
                {
                    autos.Add(type.Name.ToLower(), type);
                }
            }
        }
    }
}