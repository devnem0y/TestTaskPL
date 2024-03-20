﻿using System;
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
    [SerializeField] private Button _btnCut;
    [SerializeField] private Button _btnDecompose;
    [SerializeField] private List<Color> _btnColors;
    [SerializeField] private Toggle _uniqueFeature;
    [SerializeField] private PopUpTitle _popUpTitle;
    [SerializeField] private GameObject _rightPanel;

    private bool _isCutClick;
    private bool _isDecomposeClick;
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
    
    public void OnPopUpTitle(bool show, string title = "")
    {
        _popUpTitle.SetTitle(title);
        _popUpTitle.gameObject.SetActive(show);
    }

    private void OnTabClick(Tab tab)
    {
        if (_selectTab != null) _selectTab.Deselect();
        _selectTab = tab;
        
        UiUpdate();
    }

    private void UiUpdate()
    {
        _lblTitle.text = _spawner.CurrentElement.Title;
        _lblDescription.text = _spawner.CurrentElement.Description;
        
        _uniqueFeature.onValueChanged.RemoveAllListeners();
        _uniqueFeature.isOn = false;
        _uniqueFeature.onValueChanged.AddListener(_spawner.CurrentElement.EnableUniqueFeature);
        
        _btnCut.onClick.RemoveAllListeners();
        _btnDecompose.onClick.RemoveAllListeners();
        _isCutClick = false;
        _isDecomposeClick = false;
        _btnCut.image.color = _btnColors[0];
        _btnDecompose.image.color = _btnColors[0];
        
        _btnCut.onClick.AddListener(() =>
        {
            if (!_isCutClick)
            {
                _spawner.CurrentElement.Cut(true);
                _isCutClick = true;
                _btnCut.image.color = _btnColors[1];
            }
            else
            {
                _spawner.CurrentElement.Cut(false);
                _isCutClick = false;
                _btnCut.image.color = _btnColors[0];
            }
        });
        
        _btnDecompose.onClick.AddListener(() =>
        {
            if (!_isDecomposeClick)
            {
                _spawner.CurrentElement.Decompose(true);
                _isDecomposeClick = true;
                _btnDecompose.image.color = _btnColors[1];
            }
            else
            {
                _spawner.CurrentElement.Decompose(false);
                _isDecomposeClick = false;
                _btnDecompose.image.color = _btnColors[0];
            }
        });
        
        if (!_rightPanel.activeSelf) _rightPanel.SetActive(true);
    }
}