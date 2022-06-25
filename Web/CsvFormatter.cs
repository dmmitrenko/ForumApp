using ForumApp.Shared.DTO;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace ForumApp.Web;

public class CsvFormatter : TextOutputFormatter
{
    public CsvFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    protected override bool CanWriteType(Type? type)
    {
        if (typeof(UserDto).IsAssignableFrom(type)
            || typeof(IEnumerable<UserDto>).IsAssignableFrom(type))
        {
            return base.CanWriteType(type);
        }

        return false;
    }

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        var responce = context.HttpContext.Response;
        var buffer = new StringBuilder();

        if (context.Object is IEnumerable<UserDto>)
        {
            foreach (var user in (IEnumerable<UserDto>)context.Object)
            {
                FormatCsv(buffer, user);
            }
        }
        else
        {
            FormatCsv(buffer, (UserDto)context.Object!);
        }

        await responce.WriteAsync(buffer.ToString());
    }

    private static void FormatCsv(StringBuilder buffer, UserDto user)
    {
        buffer.AppendLine($"{user.Id},\"{user.FullName},\"{user.Nickname},\"{user.DateRegistration}");
    }
}
