using UnityEngine;

public class Spawner : MonoBehaviour, ISpawner
{
    [SerializeField] private Container _container;
    
    private Storage _storage;
    
    public IElement CurrentElement { get; private set; }

    public void Init(Storage storage)
    {
        _storage = storage;
    }
    
    public void Create(int id)
    {
        Clear();
        
        var dataEl = _storage.GetElement(id);
        var element = Instantiate(dataEl.Prefab, _container.transform);
        element.Init(dataEl);
        CurrentElement = element;
    }

    public void Clear()
    {
        if (_container.transform.childCount > 0)
        {
            Destroy(_container.transform.GetChild(0).gameObject);
        }
        
        _container.Refresh();
    }
}