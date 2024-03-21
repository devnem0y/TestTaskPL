using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpTitle : MonoBehaviour
{
    [SerializeField] private TMP_Text _lblTitle;

    public void SetTitle(string title)
    {
        _lblTitle.text = title;
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
    
    private void Update()
    {
        if (gameObject.activeSelf) transform.position = Input.mousePosition;
    }
}