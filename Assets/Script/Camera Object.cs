using UnityEngine;

public class CameraObject : MonoBehaviour
{
    public Transform Cameraobject; 

    void Update()
    {
        
        Vector3 newPosition = new Vector3(0, 0, Cameraobject.position.z);

        
        transform.position = newPosition;

        
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}

