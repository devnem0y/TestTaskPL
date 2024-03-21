public interface ISpawner
{
    public IElement CurrentElement { get; }

    void Create(int id);
    void Clear();
}