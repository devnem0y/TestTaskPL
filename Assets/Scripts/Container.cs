using UnityEngine;

public class Container : MonoBehaviour
{
    private const float ROTATION_SPEED = 5500f;
    private const float ZOOM_SPEED = 1100f;
    
    private Vector3 _targetPosition;

    public void Refresh()
    {
        _targetPosition = Vector3.zero;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
    }
    
    private void ZoomInOut()
    {
        _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y,
            Mathf.Clamp(_targetPosition.z - Input.GetAxis("Mouse ScrollWheel"), -3f,
                2.5f));
        
        transform.localPosition = Vector3.Lerp(transform.localPosition, _targetPosition,
            ZOOM_SPEED * Time.deltaTime);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var axisX = Input.GetAxis("Mouse Y");
            var axisY = -Input.GetAxis("Mouse X");
            var euler = new Vector3(axisX, axisY, 0f) * ROTATION_SPEED * Time.deltaTime;
            transform.Rotate(euler, Space.World);
        }
        
        ZoomInOut();
    }
}