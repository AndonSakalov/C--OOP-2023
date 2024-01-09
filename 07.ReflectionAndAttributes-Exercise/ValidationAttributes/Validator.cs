using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {

        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();

            PropertyInfo[] propertiesInfo = type.GetProperties()
                .Where(p => p.CustomAttributes
                .Any(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.AttributeType)))
                .ToArray();

            foreach (PropertyInfo property in propertiesInfo)
            {
                IEnumerable<MyValidationAttribute> attributes = property.GetCustomAttributes().Where(ca => typeof(MyValidationAttribute)
                .IsAssignableFrom(ca.GetType())).Cast<MyValidationAttribute>().ToArray();
                foreach (MyValidationAttribute attr in attributes)
                {
                    if (!attr.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
