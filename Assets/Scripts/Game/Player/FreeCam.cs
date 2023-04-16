using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCam : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float freeLookSensitivity = 3f;
    public float zoomSensitivity = 10f;

    public const float minZoom = -6.0f;
    public const float maxZoom = -0.01f;
    [SerializeField]
    [Range(minZoom, maxZoom)]
    public float zoomFactor = -1;

    private bool looking = false;

    [Header("References")]
    public GameObject player;

    void Update()
    {
        if (looking)
        {
            float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
            float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
            transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
            transform.position = player.transform.position + transform.forward * zoomFactor * this.zoomSensitivity;
        }

        float axis = Input.GetAxis("Mouse ScrollWheel");
        if (axis != 0)
        {
            if (zoomFactor + axis <= minZoom)
                zoomFactor = minZoom;
            else if (zoomFactor + axis >= maxZoom)
                zoomFactor = maxZoom;
            else
                zoomFactor += axis;
            transform.position = player.transform.position + transform.forward * zoomFactor * this.zoomSensitivity;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartLooking();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            StopLooking();
        }
    }

    void OnDisable()
    {
        StopLooking();
    }

    public void StartLooking()
    {
        looking = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void StopLooking()
    {
        looking = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}