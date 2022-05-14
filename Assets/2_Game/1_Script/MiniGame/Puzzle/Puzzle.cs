using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public GameObject PuzzlePosSet;
    public GameObject puzzlePieceSet;
    public List<Move> pieceArr = new List<Move>();
    public Move piece;
    public int[] Correct = new int[25];
    public GameObject Clear;
    public int count;

    void Start()
    {
        Clear.SetActive(false);
        for (int i = 0; i < Correct.Length; i++)
        {
            Correct[i] = 0;
        }
    }

    public void CheckedPuzzle(int Corret_n, int piece_n)
    {
        Correct[Corret_n] = piece_n;
        ArrayCheck();
    }
    void ArrayCheck()
    {
        for (int i = 0; i < Correct.Length; i++)
        {
            if(Correct[i] == 0)
            {
                break;
            }
            if (i == Correct.Length - 1)
            {
                Check();
            }
        }
    }
    void Check()
    {
        for(int i = 0; i < Correct.Length; i++)
        {
            if(Correct[i] == i + 1)
            {
                continue;
            }
            else
            {
                for (int j = 0; j < pieceArr.Count; j++)
                    pieceArr[j].RePlace();
                return;
            }

        }
        Time.timeScale = 0;
        Clear.SetActive(true);
    }
}   
