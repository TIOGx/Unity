using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour // 게임에 사용된 UI들을 관리하는 매니저
{
    public static UIManager instance;

    [SerializeField]
    private GameObject ChoosePieceCanvas;
    [SerializeField]
    private GameObject SelectPosCanvas;
    [SerializeField]
    private GameObject ChooseClassCanvas;

    public GameObject GetSelectCanvas()
    {
        return SelectPosCanvas;
    }

    // ChoosePieceCanvas
    public void ChooseCanvasFalse()
    {
        ChoosePieceCanvas.SetActive(false);
    }
    public void ChooseCanvasTrue()
    {
        ChoosePieceCanvas.SetActive(true);
    }

    //SelectPosCanvas
    public void SelectCanvasFalse()
    {
        SelectPosCanvas.SetActive(false);
    }
    public void SelectCanvasTrue()
    {
        SelectPosCanvas.SetActive(true);
    }

    //ChooseClassCanvas
    public void ChooseClassCanvasFalse()
    {
        ChooseClassCanvas.SetActive(false);
    }
    public void ChooseClassCanvasTrue()
    {
        ChooseClassCanvas.SetActive(true);
    }

    public void Start()
    {
        instance = this;
        ChoosePieceCanvas.SetActive(false);
        SelectPosCanvas.SetActive(false);
    }
}