using System.Reflection;

namespace Clinica.Utilities.HelperExtensions
{
    public static class GetEntityProperties
    {
        public static Dictionary<string, object> GetPropertiesWithValues<T>(this T enity)
        {
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            var entityParams = new Dictionary<string, object>();

            foreach (PropertyInfo property in propertyInfos)
            {
                object value = property.GetValue(enity)!; // ! = quitar referencia de nulos

                if (value != null)
                {
                    entityParams[property.Name] = value;
                }
            }
            return entityParams;
        }
    }
}
