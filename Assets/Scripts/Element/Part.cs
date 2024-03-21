using UnityEngine;

public class Part : MonoBehaviour
{
    [SerializeField] private string _title;
    
    private void OnMouseEnter()
    {
        Bootstrap.Instance.View.OnPopUpTitle(true, _title);
    }

    private void OnMouseExit()
    {
        Bootstrap.Instance.View.OnPopUpTitle(false);
    }
}