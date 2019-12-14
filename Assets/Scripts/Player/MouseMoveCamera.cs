using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoveCamera : MonoBehaviour
{
    private Vector2 mousePosition;
    private Vector2 mouseDirection;
    private Transform playerBody;

    private void Start()
    {
        playerBody = this.transform.parent.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        LookWithMouse();
    }

    void LookWithMouse()
    {
        Vector2 mouseChange = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * 1.5f;

        mouseDirection += mouseChange;

        this.transform.localRotation = Quaternion.AngleAxis(-mouseDirection.y, Vector3.right);

        playerBody.localRotation = Quaternion.AngleAxis(mouseDirection.x, Vector3.up);


    }


}
