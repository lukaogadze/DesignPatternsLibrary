using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace EmployeeTests.Extensions
{
    public static class FormCollectionExtensions
    {
        /// <summary>
        /// Create a FormCollection from all the properties of an object that 
        /// are not set to a default value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static FormCollection ToFormCollection(this object data)
        {
            var dictionary =
                    data.GetType()
                        .GetProperties()                        
                        .ToDictionary(p => p.Name, p => p.GetValue(data, null) ?? "");
            
            var collection = new FormCollection();
            foreach(var kvp in dictionary)
            {
                collection.Add(kvp.Key, kvp.Value.ToString());
            }
            return collection;
        }       
    }
}