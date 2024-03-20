using TMPro;
using UnityEngine;

public class PopUpTitle : MonoBehaviour
{
    [SerializeField] private TMP_Text _lblTitle;

    public void SetTitle(string title)
    {
        _lblTitle.text = title;
    }
}