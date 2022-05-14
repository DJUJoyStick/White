using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnMng : MonoBehaviour
{
    public GameObject[] MiniGameBtnGams;
    public GameObject MiniGameCloseBtnGams;
    public CameraShake CamShakeSc;


    public void MiniGame(int kind)
    {
        SGameMng.I.bMinGame = true;

        if (kind.Equals(1))
            SGameMng.I.MiniGams = Instantiate(SGameMng.I.MiniGamPre[kind - 1], SGameMng.I.CanvasTr) as GameObject;
        else if (kind.Equals(2))
        {
            SGameMng.I.MiniGams = Instantiate(SGameMng.I.MiniGamPre[kind - 1], SGameMng.I.CanvasTr) as GameObject;
            CamShakeSc.enabled = true;
        }
        for (int i = 0; i < MiniGameBtnGams.Length; i++)
            MiniGameBtnGams[i].SetActive(false);
        MiniGameCloseBtnGams.SetActive(true);

        SGameMng.I.nMinGameNum = kind;
    }

    public void MiniGameCloseBtn()
    {
        Destroy(SGameMng.I.MiniGams);

        for (int i = 0; i < MiniGameBtnGams.Length; i++)
            MiniGameBtnGams[i].SetActive(true);
        MiniGameCloseBtnGams.SetActive(false);

        if (SGameMng.I.nMinGameNum.Equals(2))
            CamShakeSc.enabled = false;

        SGameMng.I.nMinGameNum = 0;
    }
}
