using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform playerBody;
    public CharacterController controller;
    public float movespeed = 10f;
    public float mouseSensitivity = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        playerBody.Rotate(Vector3.up * mouseX);
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * movespeed * Time.deltaTime);
    }
}
