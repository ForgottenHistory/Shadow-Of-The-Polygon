using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////////
    // PUBLIC VARIABLES
    ////////////////////////////////////////////////////////////////////

    public PlayerController playerController = null;

    ////////////////////////////////////////////////////////////////////
    // PRIVATE VARIABLES
    ////////////////////////////////////////////////////////////////////

    private void Start()
    {
        playerController.Initialize();
    }
    
    ////////////////////////////////////////////////////////////////////
}
