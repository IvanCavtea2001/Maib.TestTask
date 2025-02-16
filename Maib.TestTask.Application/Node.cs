namespace Maib.TestTask.Application;

public struct Node
{
    private readonly SortedList<string, Node> childs;

    public Node(int id, int parentId, string text)
    {
        Id = id;
        ParentId = parentId;
        Text = text;

        this.childs = new ();
    }

    public int Id { get; }
    public int ParentId { get; }
    public string Text { get; }

    public void AddChild(Node child) => this.childs.Add(child.Text, child);

    public IEnumerable<Node> GetChilds() => this.childs.Values;
}