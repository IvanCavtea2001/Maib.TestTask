using Maib.TestTask.Application;
using System.Text.RegularExpressions;

namespace Maib.TestTask.Infrastructure;

public static class NodeConverter
{
    private const string pattern = @"^\s*\d+\s*\|\s*\d+\s*\|\s*.+\s*$";
    private const char separator = '|';

    public static Node FromString(string text)
    {
        if (!Regex.IsMatch(text, pattern))
        {
            throw new ArgumentException("Cannot convert string to Node");
        }

        var valueArray = text.Split(separator);

        return new Node(
            id: Convert.ToInt32(valueArray[0].Trim()),
            parentId: Convert.ToInt32(valueArray[1].Trim()),
            text: valueArray[2].Trim());
    }
}