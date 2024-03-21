using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tab : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private List<Color> _colors;
    
    [HideInInspector] public UnityEvent<Tab> OnClick;
    
    private Action<int> _callback;
    private int _id;
    private bool _isSelected;
    
    public void Init(int id, string title, Action<int> action)
    {
        _id = id;
        _callback = action;

        _label.text = title;
        
        ChangeState(false);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isSelected) return;
        
        _callback?.Invoke(_id);
        OnClick?.Invoke(this);
        ChangeState(true);
    }

    public void Deselect()
    {
        ChangeState(false);
    }

    private void ChangeState(bool isSelected)
    {
        _isSelected = isSelected;
        _image.color = _isSelected ? _colors[1] : _colors[0];
    }
}