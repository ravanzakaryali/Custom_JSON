using Microsoft.VisualBasic;
using System.Collections;
using System.Data.Common;
using System.Reflection;
using System.Text;

namespace Custom_JSON;

public class CustomJSON
{
    public static string Serialze<T>(T entity)
    {
        StringBuilder result = new StringBuilder();
        var properties = entity.GetType().GetProperties();
        result.Append('{');
        for (int i = 0; i < properties.Length; i++)
        {
            var value = properties[i].GetValue(entity);
            if (value is null)
            {
                result.Append($"\"{properties[i].Name}\":null");
            }
            else if (properties[i].PropertyType == typeof(string))
            {
                result.Append($"\"{properties[i].Name}\":\"{value}\",");
            }
            else if (value is ICollection)
            {
                result.Append($"\"{properties[i].Name}\":[");
                Reqursive((ICollection)value, ref result);
                result.Append(']');
            }
            else
            {
                var character = properties.Length - 1 != i ? "," : "";
                result.Append($"\"{properties[i].Name}\":{value}{character}");
            }
        }
        result.Append('}');
        return result.ToString();
    }
    private static void Reqursive(ICollection value, ref StringBuilder builder)
    {
        foreach (var item in value)
        {
            builder.Append(Serialze(item));
        }
    }
}
