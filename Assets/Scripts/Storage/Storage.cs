using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Storage", menuName = "Storage/Elements", order = 0)]
public class Storage : ScriptableObject
{
    [SerializeField] private List<ElementData> _elements;

    public ElementData GetElement(int id)
    {
        return _elements.FirstOrDefault(element => element.Id == id);
    }

    public Dictionary<int, string> GetList()
    {
        return _elements.ToDictionary(element => element.Id, element => element.Title);
    }
}