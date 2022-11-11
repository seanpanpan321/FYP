using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;
    const float MaxUpDownRotation = 60;

    private float xSensitivity = 180f;
    private float ySensitivity = 180f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        //camera rotation for looking up/down
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -MaxUpDownRotation, MaxUpDownRotation);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //rotate the player to look left/right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
