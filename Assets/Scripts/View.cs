using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour, ITitle
{
    [SerializeField] private Tab _tabPrefab;
    [SerializeField] private Transform _tabsPanel;
    [SerializeField] private TMP_Text _lblTitle;
    [SerializeField] private TMP_Text _lblDescription;
    [SerializeField] private Toggle _uniqueFeature;
    [SerializeField] private PopUpTitle _popUpTitle;
    [SerializeField] private GameObject _rightPanel;
    
    private Tab _selectTab;
    private ISpawner _spawner;

    private void Awake()
    {
        _rightPanel.SetActive(false);
    }

    public void Init(Dictionary<int, string> list, ISpawner spawner)
    {
        _spawner = spawner;
        
        foreach(var kvp in list)
        {
            var tab = Instantiate(_tabPrefab, _tabsPanel);
            tab.Init(kvp.Key, kvp.Value, _spawner.Create);
            tab.OnClick.AddListener(OnTabClick);
        }
    }

    private void OnTabClick(Tab tab)
    {
        if (_selectTab != null) _selectTab.Deselect();
        _selectTab = tab;
        
        _lblTitle.text = _spawner.CurrentElement.Title;
        _lblDescription.text = _spawner.CurrentElement.Description;
        
        _uniqueFeature.onValueChanged.RemoveAllListeners();
        _uniqueFeature.isOn = false;
        _uniqueFeature.onValueChanged.AddListener(_spawner.CurrentElement.EnableUniqueFeature);
        
        if (!_rightPanel.activeSelf) _rightPanel.SetActive(true);
    }
    
    public void OnPopUpTitle(bool show, string title = "")
    {
        _popUpTitle.SetTitle(title);
        _popUpTitle.gameObject.SetActive(show);
    }
}