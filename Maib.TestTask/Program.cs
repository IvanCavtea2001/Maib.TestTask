using Maib.TestTask.Application;
using Maib.TestTask.Application.Infrastructure;
using Maib.TestTask.Infrastructure;

namespace Maib.TestTask;

public class Program
{
    public static async Task Main(string[] args)
    {
        IReadAsync<IReadOnlyList<Node>, string> reader = new FileReader();

        var service = new NodeService(reader);

        var tree = await service.CreateRawTreeAsync("raws.txt", default);

        tree.ShowTree();
    }
}