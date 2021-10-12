using System;
using System.Linq;
using System.Reflection;

namespace RamenOkiDoki.Helpers
{
    public class ReflectionHelper
    {
        public static object GetPropValue(object source, string propertyName)
        {
            var property = source.GetType().GetRuntimeProperties().FirstOrDefault(p => string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase));
            return property?.GetValue(source);
        }
        public static string GetPropertyName(object source)
        {
            return source.GetType().GetProperties().ToString();
        }
        
        public static PropertyInfo[] GetProperties(object source)
        {
            return source.GetType().GetProperties();
        }
    }
}
