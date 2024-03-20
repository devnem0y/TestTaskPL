using UnityEngine;

public abstract class ElementBase : MonoBehaviour, IElement
{
    [SerializeField] private GameObject _partCut;
    [SerializeField] private Animator _animatorDecompose;
    
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    
    public void Init(IElementData data)
    {
        Id = data.Id;
        Title = data.Title;
        Description = data.Description;
    }
    
    public void Cut(bool activate)
    {
        _partCut.SetActive(!activate);
    }

    public void Decompose(bool activate)
    {
        _animatorDecompose.Play(activate ? "On" : "Off");
    }

    public virtual void EnableUniqueFeature(bool activate)
    {
        
    }
}
