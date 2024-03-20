using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour, ITitle
{
    [SerializeField] private Tab _tabPrefab;
    [SerializeField] private TMP_Text _lblName;
    [SerializeField] private TMP_Text _lblDescription;
    [SerializeField] private Toggle _uniqueFeature;
    [SerializeField] private PopUpTitle _popUpTitle;
    
    private Tab _selectTab;
    private ISpawner _spawner;
    
    public void Init(Dictionary<int, string> list, ISpawner spawner)
    {
        _spawner = spawner;
        
        foreach(var kvp in list)
        {
            var tab = Instantiate(_tabPrefab);
            tab.Init(kvp.Key, kvp.Value, _spawner.Create);
            tab.OnClick.AddListener(OnTabClick);
        }
    }

    private void OnTabClick(Tab tab)
    {
        _selectTab.Deselect();
        _selectTab = tab;

        _lblName.text = _spawner.CurrentElement.Title;
        _lblDescription.text = _spawner.CurrentElement.Description;
        
        _uniqueFeature.onValueChanged.RemoveAllListeners();
        _uniqueFeature.isOn = false;
        _uniqueFeature.onValueChanged.AddListener(_spawner.CurrentElement.EnableUniqueFeature);
    }
    
    public void OnPopUpTitle(bool show, string title = "")
    {
        _popUpTitle.SetTitle(title);
        _popUpTitle.gameObject.SetActive(show);
    }
}