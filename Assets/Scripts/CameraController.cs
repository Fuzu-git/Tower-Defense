using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float flatSpeed = 30f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 70f;


    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * flatSpeed * Time.deltaTime, Space.World);
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.back * flatSpeed * Time.deltaTime, Space.World);
        }
        
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.left * flatSpeed * Time.deltaTime, Space.World);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.right * flatSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        Vector3 position = transform.position;

        position.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;
    }
}
