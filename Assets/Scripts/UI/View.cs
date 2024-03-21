using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour, ITitle
{
    [SerializeField] private Tab _tabPrefab;
    [SerializeField] private Transform _tabsPanel;
    [SerializeField] private GameObject _title;
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
        _title.SetActive(false);
        _popUpTitle.gameObject.SetActive(false);
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
        UiReset();
        
        _lblTitle.text = _spawner.CurrentElement.Title;
        LayoutRebuilder.ForceRebuildLayoutImmediate(_title.GetComponent<RectTransform>());
        _lblDescription.text = _spawner.CurrentElement.Description;
        
        ButtonUpdate(_btnCut, _isCutClick);
        ButtonUpdate(_btnDecompose, _isDecomposeClick);
        
        _uniqueFeature.onValueChanged.AddListener(_spawner.CurrentElement.EnableUniqueFeature);
        
        if (!_title.activeSelf) _title.SetActive(true);
        if (!_rightPanel.activeSelf) _rightPanel.SetActive(true);
    }
    
    private void UiReset()
    {
        _uniqueFeature.onValueChanged.RemoveAllListeners();
        _uniqueFeature.isOn = false;
        
        _btnCut.onClick.RemoveAllListeners();
        _btnDecompose.onClick.RemoveAllListeners();
        _isCutClick = false;
        _isDecomposeClick = false;
        _btnCut.image.color = _btnColors[0];
        _btnDecompose.image.color = _btnColors[0];
    }

    private void ButtonUpdate(Button button, bool isClick)
    {
        button.onClick.AddListener(() =>
        {
            if (!isClick)
            {
                _spawner.CurrentElement.Decompose(true);
                isClick = true;
                button.image.color = _btnColors[1];
            }
            else
            {
                _spawner.CurrentElement.Decompose(false);
                isClick = false;
                button.image.color = _btnColors[0];
            }
        });
    }
}