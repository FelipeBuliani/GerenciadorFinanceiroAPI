using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GerenciadorFinanceiroAPI.ViewModels
{
    /// <summary>
    /// Used to cache enum values descriptions mapper
    /// </summary>
    public class DescribedEnumHandler<T>
    {
        private readonly IDictionary<T, string> toDescription = new Dictionary<T, string>();
        private readonly IDictionary<string, T> fromDescription = new Dictionary<string, T>();

        private const BindingFlags PUBLIC_STATIC = BindingFlags.Public | BindingFlags.Static;

        /// <summary>
        /// Creates a new DescribedEnumHandler instance for a given enum type
        /// </summary>
        public DescribedEnumHandler()
        {
            var type = typeof(T);
            var enumEntrys = from f in type.GetFields(PUBLIC_STATIC)
                             let attributes = f.GetCustomAttributes(typeof(DescriptionAttribute), false)
                             let description =
                                attributes.Length == 1
                                    ? ((DescriptionAttribute)attributes[0]).Description
                                    : f.Name
                             select new
                             {
                                 Value = (T)Enum.Parse(type, f.Name),
                                 Description = description
                             };

            foreach (var enumEntry in enumEntrys)
            {
                toDescription[enumEntry.Value] = enumEntry.Description;
                fromDescription[enumEntry.Description] = enumEntry.Value;
            }
        }

        /// <summary>
        /// Extracts the description for the given enum value.
        /// <remarks>if no description was set for the given value, it's name will be retrieved</remarks>
        /// </summary>
        /// <param name="value">The enum value</param>
        /// <returns>The value's description</returns>
        public string GetDescriptionFrom(T value)
        {
            return toDescription[value];
        }

        /// <summary>
        /// Parse the given string and return the enum value for with the given string acts as description
        /// </summary>
        /// <param name="description">The given description</param>
        /// <returns>A matching enum value</returns>
        public T GetValueFrom(string description)
        {
            return fromDescription[description];
        }
    }

    /// <summary>
    /// Provide access to enum helpers
    /// </summary>
    public static class Enum<T>
    {
        private static readonly System.Type enumType;
        private static readonly DescribedEnumHandler<T> handler;

        static Enum()
        {
            enumType = typeof(T);
            if (enumType.IsEnum == false)
                throw new ArgumentException(string.Format("{0} is not an enum", enumType));

            handler = new DescribedEnumHandler<T>();
        }

        /// <summary>
        /// Extract the description for a given enum value
        /// </summary>
        /// <param name="value">An enum value</param>
        /// <returns>It's description, or it's name if there's no registered description for the given value</returns>
        public static string GetDescriptionOf(T value)
        {
            return handler.GetDescriptionFrom(value);
        }

        /// <summary>
        /// Gets the enum value for a given description or value
        /// </summary>
        /// <param name="descriptionOrName">The enum value or description</param>
        /// <returns>An enum value matching the given string value, as description (using <see cref="DescriptionAttribute"/>) or as value</returns>
        public static T From(string descriptionOrName)
        {
            if (descriptionOrName == null)
                return default(T);

            return handler.GetValueFrom(descriptionOrName);
        }
    }
}