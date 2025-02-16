using Maib.TestTask.Application;
using Maib.TestTask.Application.Infrastructure;

namespace Maib.TestTask.Infrastructure;

public class FileReader : IReadAsync<IReadOnlyList<Node>, string>
{
    public async Task<IReadOnlyList<Node>> ReadAsync(string criteria, CancellationToken cancellationToken)
    {
        var result = new List<Node>();

        var raws = await File.ReadAllLinesAsync(criteria, cancellationToken);

        foreach (var raw in raws)
        {
            var node = NodeConverter.FromString(raw);
            result.Add(node);
        }

        return result;
    }
}
