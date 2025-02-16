namespace Maib.TestTask.Application;

public class RawTree
{
    private readonly Node root;
    private readonly Dictionary<int, Node> allNodes;

    public RawTree(IReadOnlyList<Node> nodes)
    {
        this.allNodes = nodes.ToDictionary(node => node.Id);

        var isRootPresent = this.allNodes.TryGetValue(0, out var root);

        if(!isRootPresent || root.ParentId != 0 || !root.Text.Equals("root"))
        {
            throw new ArgumentException("The root element was not found or invalid.");
        }

        this.root = root;

        this.Initialize();
    }

    private void Initialize()
    {
        foreach(var node in this.allNodes.Where(x => x.Key != 0))
        {
            var isParentNodeExists = this.allNodes.TryGetValue(node.Value.ParentId, out var parent);

            if (!isParentNodeExists || parent.Id.Equals(node.Value.Id)) continue;

            parent.AddChild(node.Value);
        }
    }

    public void ShowTree()
    {
        this.ShowNode(this.root, 0);
    }

    private void ShowNode(Node node, int depth)
    {
        var tabSymbol = new string('\t', depth);

        Console.WriteLine($"{tabSymbol}{node.Id}|{node.ParentId}|{node.Text}");

        foreach(var childNode in node.GetChilds())
        {
            ShowNode(childNode, depth + 1);
        }
    }
}