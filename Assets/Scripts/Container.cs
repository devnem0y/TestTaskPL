using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _zoomSpeed;

    public void Refresh()
    {
        //TODO: Сброс, возврат в начальное состояние
    }
    
    private void ZoomInOut()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //TODO: Rodate
        }
        
        ZoomInOut();
    }
}