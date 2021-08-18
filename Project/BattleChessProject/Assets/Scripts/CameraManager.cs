using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public GameObject BlackTeamC;
    public GameObject WhiteTeamC;
    private Vector3 OriginCamerapos;
    private Quaternion OriginCamerarot;
    private Vector3 SharedCamerapos;
    private Quaternion SharedCamerarot;
    void Start()
    {
        instance = this;
        BlackTeamCameraOn();
        //SharedCamerapos = new Vector3(3.5f, 7.05f, 3.5f);
        //SharedCamerarot = Quaternion.Euler(90f, 0, 0);
        //SharedCamerapos = new Vector3(3.5f, 7.05f, 3.5f);
        //SharedCamerarot = Quaternion.Euler(90f, 180f, 0);
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
    IEnumerator CameraMoveCoroutine(Transform TeamOriginTransform)
    {
        float elapsedTime = 0;
        float waitTime = 0.2f;
        while (waitTime > elapsedTime)
        {
            elapsedTime += Time.deltaTime;

            TeamOriginTransform.position = Vector3.Lerp(TeamOriginTransform.position, SharedCamerapos, 0.2f);
            TeamOriginTransform.rotation = Quaternion.Lerp(TeamOriginTransform.rotation, SharedCamerarot, 0.2f);
            yield return null;

        }
        TeamOriginTransform.position = SharedCamerapos;
        TeamOriginTransform.rotation = SharedCamerarot;
    }


    IEnumerator InitCamCoroutine(Transform TeamOriginTransform)
    {
        float elapsedTime = 0;
        float waitTime = 0.2f;
        while (waitTime > elapsedTime)
        {
            elapsedTime += Time.deltaTime;
            TeamOriginTransform.position = Vector3.Lerp(TeamOriginTransform.position, OriginCamerapos, 0.2f);
            TeamOriginTransform.rotation = Quaternion.Lerp(TeamOriginTransform.rotation, OriginCamerarot, 0.2f);
            yield return null;
        }
        TeamOriginTransform.position = OriginCamerapos;
        TeamOriginTransform.rotation = OriginCamerarot;
    }


    public void ClickPieceCamera()
    {

        if (GameManager.instance.GetPlayer())
        {
            OriginCamerapos = BlackTeamC.transform.position;
            OriginCamerarot = BlackTeamC.transform.rotation;
            SharedCamerapos = new Vector3(3.5f, 7.05f, 3.5f);
            SharedCamerarot = Quaternion.Euler(90f, 0, 0);
            StartCoroutine(CameraMoveCoroutine(BlackTeamC.transform));
            

        }
        else
        {
            OriginCamerapos = WhiteTeamC.transform.position;
            OriginCamerarot = WhiteTeamC.transform.rotation;
            SharedCamerapos = new Vector3(3.5f, 7.05f, 3.5f);
            SharedCamerarot = Quaternion.Euler(90f, 180f, 0);
            StartCoroutine(CameraMoveCoroutine(WhiteTeamC.transform));
            

        }
    }
    public void InitailizeCamera()
    {
        if (GameManager.instance.GetPlayer())
        {
            StartCoroutine(InitCamCoroutine(BlackTeamC.transform));
        }
        else
        {
            StartCoroutine(InitCamCoroutine(WhiteTeamC.transform));
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