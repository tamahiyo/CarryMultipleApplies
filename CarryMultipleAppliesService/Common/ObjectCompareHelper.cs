using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarryMultipleAppliesService.Common
{
    public class ObjectCompareHelper
    {
        /// <summary>
        /// objectの比較処理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="object1"></param>
        /// <param name="object2"></param>
        /// <returns></returns>
        public static bool Compare<T>(T object1, T object2)
        {
            Type type = typeof(T);

            if (object.Equals(object1, default(T)) || object.Equals(object2, default(T)))
            {
                return false;
            }

            foreach (PropertyInfo property in type.GetProperties())
            {

                var value1 = NormalizedValue(type, property, object1);
                var value2 = NormalizedValue(type, property, object2);
                if (value1 != value2)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 整形した値を取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="property"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static string NormalizedValue<T>(Type type, PropertyInfo property, T obj)
        {
            var value = type.GetProperty(property.Name).GetValue(obj, null);
            if (value == null)
            {
                return string.Empty;
            }

            var propType = type.GetProperty(property.Name);
            return value.ToString().Trim();
        }
    }
}
