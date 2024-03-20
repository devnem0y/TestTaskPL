using UnityEngine;

public abstract class ElementBase : MonoBehaviour, IElement
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    
    public void Init(IElementData data)
    {
        Id = data.Id;
        Title = data.Title;
        Description = data.Description;
    }
    
    public void Cut()
    {
        
    }

    public void Decompose()
    {
        
    }

    public virtual void EnableUniqueFeature(bool activate)
    {
        
    }
}
