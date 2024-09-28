using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] GameObject camera;

    // Update is called once per frame
    void Update()
    {
        // Basic movements
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.RotateAround(camera.transform.position, Vector3.up, -100 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.RotateAround(camera.transform.position, Vector3.up, 100 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(Vector3.forward * 100 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.Translate(Vector3.forward * -100 * Time.deltaTime);
        }
    }
}
