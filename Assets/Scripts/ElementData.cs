using UnityEngine;

[System.Serializable]
public class ElementData : IElementData
{
    [SerializeField] private string _title;
    public string Title => _title;

    [SerializeField] private int _id;
    public int Id => _id;
    
    [SerializeField, Multiline(6)] private string _description;
    public string Description => _description;
    
    [SerializeField] private ElementBase _prefab;
    public ElementBase Prefab => _prefab;
}