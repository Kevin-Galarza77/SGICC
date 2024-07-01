using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestCrud
{
    public class UtilityTest<T>
    {
        public static string ToStringObject(T entity)
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                object value = null;
                try
                {
                    value = prop.GetValue(entity, null);
                }
                catch (Exception ex)
                {
                    value = null;
                }
                if (value != null)
                {
                    sb.AppendLine($" * {prop.Name}: {value}");
                }
            }
            return sb.ToString();
        }
    }
}
