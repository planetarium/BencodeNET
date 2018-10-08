using BencodeNET.Torrents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#if NETSTANDARD
using System;
using System.Reflection;
#endif

namespace BencodeNET
{
    internal static class UtilityExtensions
    {
        public static bool IsDigit(this char c)
        {
            return c >= '0' && c <= '9';
        }

        public static MemoryStream AsStream(this string str, Encoding encoding)
        {
            return new MemoryStream(encoding.GetBytes(str));
        }

        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.TryGetValue(key, out TValue value) ? value : default(TValue);
        }

        public static void Write(this Stream stream, char c)
        {
            stream.WriteByte((byte)c);
        }

        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> source)
        {
            return source.SelectMany(x => x);
        }

        public static IEnumerable<T> Flatten<T>(this IList<IList<T>> source)
        {
            return source.SelectMany(x => x);
        }

        public static bool HasFlag(this Enum variable, Enum value)
        {
            if (variable == null)
                return false;

            if (value == null)
                throw new ArgumentNullException("value");

            // Not as good as the .NET 4 version of this function, but should be good enough
            if (!Enum.IsDefined(variable.GetType(), value))
            {
                throw new ArgumentException(string.Format(
                    "Enumeration type mismatch.  The flag is of type '{0}', was expecting '{1}'.",
                    value.GetType(), variable.GetType()));
            }

            ulong num = Convert.ToUInt64(value);
            return ((Convert.ToUInt64(variable) & num) == num);
        }

#if NETSTANDARD
        public static bool IsAssignableFrom(this Type type, Type otherType)
        {
            return type.GetTypeInfo().IsAssignableFrom(otherType.GetTypeInfo());
        }
#endif
    }
}
