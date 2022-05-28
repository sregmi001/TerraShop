using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace TerraShop.Api.Utils
{
    /// <summary>
    /// Shamelessly copied from https://github.com/domaindrivendev/Swashbuckle.WebApi/blob/5489aca0d2dd7946f5569341f621f581720d4634/Swashbuckle.Core/Swagger/TypeExtensions.cs
    /// </summary>
    public static class TypeExtensions
    {
        public static string FriendlyId(this Type type, bool fullyQualified = false)
        {
            string? typeName = fullyQualified
                ? type.FullNameSansTypeParameters().Replace("+", ".")
                : type.Name;

            if (type.IsGenericType)
            {
                string[]? genericArgumentIds = type.GetGenericArguments()
                    .Select(t => t.FriendlyId(fullyQualified))
                    .ToArray();

                return new StringBuilder(typeName)
                    .Replace(string.Format("`{0}", genericArgumentIds.Length), string.Empty)
                    .AppendFormat("[{0}]", string.Join(",", genericArgumentIds).TrimEnd(','))
                    .ToString();
            }

            return typeName;
        }

        public static string FullNameSansTypeParameters(this Type type)
        {
            string? fullName = type.FullName;
            if (string.IsNullOrEmpty(fullName))
            {
                fullName = type.Name;
            }

            int chopIndex = fullName.IndexOf("[[");
            return chopIndex == -1 ? fullName : fullName[..chopIndex];
        }

        public static string[] GetEnumNamesForSerialization(this Type enumType)
        {
            return enumType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                .Select(fieldInfo =>
                {
                    EnumMemberAttribute? memberAttribute = fieldInfo.GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
                    return memberAttribute == null || string.IsNullOrWhiteSpace(memberAttribute.Value)
                        ? fieldInfo.Name
                        : memberAttribute.Value;
                })
                .ToArray();
        }
    }
}
