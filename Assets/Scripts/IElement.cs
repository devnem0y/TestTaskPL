public interface IElement
{
    public int Id { get; }
    public string Title { get; }
    public string Description { get; }

    void Cut();
    void Decompose();
    void EnableUniqueFeature(bool activate);
}