using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Comman
{
    public static class General
    {

        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            List<T> list = new List<T>();

            foreach (DataRow row in table.Rows)
            {
                T obj = new T();

                foreach (var prop in typeof(T).GetProperties())
                {
                    if (table.Columns.Contains(prop.Name) && !DBNull.Value.Equals(row[prop.Name]))
                    {
                        prop.SetValue(obj, Convert.ChangeType(row[prop.Name], prop.PropertyType), null);
                    }
                }

                list.Add(obj);
            }

            return list;
        }

        public enum HealthStatus
        {
            Normal = 1,
            High = 2,
            Low = 3
        }


    }
}
