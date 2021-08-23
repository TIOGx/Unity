using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField]
    private Text teamcolorCanvas;
    [SerializeField]
    private Text blackteamcostText;
    [SerializeField]
    private Text whiteteamcostText;

    [SerializeField]
    private int blackteamcost;
    [SerializeField]
    private int whiteteamcost;

    public void SetBlackTeamCost(int cost)
    {
        blackteamcost = cost;
    }
    public int GetBlackTeamCost()
    {
        return blackteamcost;
    }
    public void SetWhiteTeamCost(int cost)
    {
        whiteteamcost = cost;
    }
    public int GetWhiteTeamCost()
    {
        return whiteteamcost;
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
    public GameObject GetSelectCanvas()
    {
        return SelectPosCanvas;
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

    //teamcolorCanvas
    public Text GeteamcolorCanvas()
    {
        return teamcolorCanvas;

    }
    //teamcolorCanvas
    public void SetblackteamcostCanvas()
    {
        blackteamcostText.text = blackteamcost.ToString() + " Gold";

    }
    public void SetwhiteteamcostCanvas()
    {
        whiteteamcostText.text = whiteteamcost.ToString() + " Gold";
    }
    public void BlackTeamInterestSystem()
    {
        int interest = blackteamcost/10;
        if(interest >= 5)
        {
            interest = 5;
        }
        blackteamcost= blackteamcost + 5 + interest;
    }
    public void WhiteTeamInterestSystem()
    {
        int interest = whiteteamcost/10;
        if(interest >= 5)
        {
            interest = 5;
        }
        whiteteamcost= whiteteamcost + 5 + interest;
    }
    public void Start()
    {
        instance = this;
        ChoosePieceCanvas.SetActive(false);
        SelectPosCanvas.SetActive(false);
        blackteamcost = 0;
        whiteteamcost = 0;
    }
    public void Update()
    {
    }
}
