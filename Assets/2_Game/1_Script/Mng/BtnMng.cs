using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnMng : MonoBehaviour
{
    public GameObject[] MiniGameBtnGams;
    public GameObject MiniGameCloseBtnGams;
    
    public Transform CanvasTr;

    public void MiniGame(int kind)
    {
        SGameMng.I.bMinGame = true;
        if (kind.Equals(1))
        {
            SGameMng.I.MiniGams = Instantiate(SGameMng.I.MiniGamPre[kind - 1], CanvasTr) as GameObject;
        }
        else if (kind.Equals(2))
        {
            SGameMng.I.MiniGams = Instantiate(SGameMng.I.MiniGamPre[kind - 1], CanvasTr) as GameObject;
        }
        for (int i = 0; i < MiniGameBtnGams.Length; i++)
            MiniGameBtnGams[i].SetActive(false);
        MiniGameCloseBtnGams.SetActive(true);
    }

    public void MiniGameCloseBtn()
    {
        Destroy(SGameMng.I.MiniGams);
        for (int i = 0; i < MiniGameBtnGams.Length; i++)
            MiniGameBtnGams[i].SetActive(true);
        MiniGameCloseBtnGams.SetActive(false);
    }
}
