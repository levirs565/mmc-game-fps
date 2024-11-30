using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float sensitity = 200f;
    private float yaw = 0;
    private float pitch = 0;
    private Transform mCameraTransform;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mCameraTransform = transform.Find("Camera Holder");
    }

    void Update()
    {
        float dx = Input.GetAxis("Mouse X");
        float dy = Input.GetAxis("Mouse Y");
        yaw += dx * sensitity * Time.deltaTime;
        pitch -= dy * sensitity * Time.deltaTime;

        //yaw = Mathf.Clamp(yaw, -89f, 89f);
        pitch = Mathf.Clamp(pitch, -45f, 45f);

        transform.localRotation = Quaternion.Euler(0, yaw, 0);
        mCameraTransform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}
