using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ET.Luban
{
    public static class StringUtil
    {
        public static string ToStr(object o) => ToStr(o, new StringBuilder());

        public static string ToStr(object o, StringBuilder sb)
        {
            foreach (FieldInfo p in o.GetType().GetFields())
            {
                sb.Append($"{p.Name} = {p.GetValue(o)},");
            }

            foreach (PropertyInfo p in o.GetType().GetProperties())
            {
                sb.Append($"{p.Name} = {p.GetValue(o)},");
            }

            return sb.ToString();
        }

        public static string ArrayToString<T>(T[] arr) => "[" + string.Join(",", arr) + "]";

        public static string CollectionToString<T>(IEnumerable<T> arr) => "[" + string.Join(",", arr) + "]";

        public static string CollectionToString<TK, TV>(IDictionary<TK, TV> dic)
        {
            StringBuilder sb = new StringBuilder('{');
            foreach (var e in dic)
            {
                sb.Append(e.Key).Append(':');
                sb.Append(e.Value).Append(',');
            }

            sb.Append('}');
            return sb.ToString();
        }
    }
}