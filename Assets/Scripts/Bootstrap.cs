using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public static Bootstrap Instance;
    
    [SerializeField] private Storage _storage;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private View _view;

    public ITitle View => _view;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _spawner.Init(_storage);
        _view.Init(_storage.GetList(), _spawner);
    }
}