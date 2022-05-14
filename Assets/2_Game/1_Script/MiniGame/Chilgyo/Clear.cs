using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    // Start is called before the first frame update
    public CameraShake cam;
    private List<Tile> tileList; //생성한 타일 정보 저장
    public Board board;
    public BoardShake boardShake;
    public UIController ui;

    public void OnClick()
    {
        board.Correct();
        if (board.correct == false)
        {
            boardShake.VibrateBoardForTime(2.0f);
            Invoke("Delay", 2);
            
        }
        else
        {
            board.IsGameOver();
            ui.OnResultPanel();
        }
    }
    void Delay()
    {
        ui.OnClickRestart();
    }
}

