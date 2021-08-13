using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public GameObject BlackTeamC;
    public GameObject WhiteTeamC;
    void Start()
    {
        instance = this;
        BlackTeamCameraOn();
    }
    void Update()
    {
        if (Input.GetKey("1"))
        {
            BlackTeamCameraOn();
        }
        if (Input.GetKey("2"))
        {
            WhiteTeamCameraOn();
        }
    }
    public void BlackTeamCameraOn()
    {
        BlackTeamC.GetComponent<Camera>().enabled = true;
        BlackTeamC.GetComponent<AudioListener>().enabled = true;
        WhiteTeamC.GetComponent<Camera>().enabled = false;
        WhiteTeamC.GetComponent<AudioListener>().enabled = false;
    }

    public void WhiteTeamCameraOn()
    {
        WhiteTeamC.GetComponent<Camera>().enabled = true;
        WhiteTeamC.GetComponent<AudioListener>().enabled = true;
        BlackTeamC.GetComponent<Camera>().enabled = false;
        BlackTeamC.GetComponent<AudioListener>().enabled = false;
    }

}