using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour, IInitialize
{
    ////////////////////////////////////////////////////////////////////
    // PUBLIC VARIABLES
    ////////////////////////////////////////////////////////////////////

    //angle minimums
    [SerializeField]
    float xMin = -60f,
        xMax = 60f;

    //variables
    public float sens = 2.5f;

    ////////////////////////////////////////////////////////////////////
    // PRIVATE VARIABLES
    ////////////////////////////////////////////////////////////////////

    Transform playerTrans = null;

    Vector3 playerOffset = Vector3.zero;

    float rotX = 0.0f;
    float rotY = 0.0f;

    ////////////////////////////////////////////////////////////////////

    public bool isActive { get; set; } = false;

    ////////////////////////////////////////////////////////////////////

    public void Initialize()
    {
        playerTrans = transform.parent;

        transform.parent = null;

        // Set cursor to invisible and lock it to the center of the screen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Activate the script
        isActive = true;
    }

    ////////////////////////////////////////////////////////////////////

    public void Deinitialize()
    {
        // Deactivate the script
        isActive = false;
    }

    ////////////////////////////////////////////////////////////////////

    void Update()
    {
        if (isActive == false) return;

        transform.position = playerTrans.position + playerOffset;

        //rotations
        rotX += Input.GetAxis("Mouse Y") * sens;
        rotY += Input.GetAxis("Mouse X") * sens;

        rotX = Mathf.Clamp(rotX, xMin, xMax); //limit player

        //change rotations
        transform.eulerAngles = new Vector3(-rotX, rotY, transform.eulerAngles.z);
        playerTrans.rotation = Quaternion.Euler(playerTrans.rotation.x, transform.eulerAngles.y, playerTrans.rotation.z);
    }

    ////////////////////////////////////////////////////////////////////
}