using Maib.TestTask.Application.Infrastructure;

namespace Maib.TestTask.Application;

public class NodeService
{
    private readonly IReadAsync<IReadOnlyList<Node>, string> nodeReader;

    public NodeService(IReadAsync<IReadOnlyList<Node>, string> nodeReader)
    {
        this.nodeReader = nodeReader;
    }

    public async Task<RawTree> CreateRawTreeAsync(string filePath, CancellationToken cancellationToken)
    {
        var nodes = await this.nodeReader.ReadAsync(filePath, cancellationToken);

        var rawTree = new RawTree(nodes);

        return rawTree;
    }
}