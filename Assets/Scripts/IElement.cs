public interface IElement
{
    public int Id { get; }
    public string Title { get; }
    public string Description { get; }

    void Cut(bool activate);
    void Decompose(bool activate);
    void EnableUniqueFeature(bool activate);
}