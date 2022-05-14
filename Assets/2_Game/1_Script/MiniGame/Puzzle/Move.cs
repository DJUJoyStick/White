using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Move : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public int snapOffset = 50;
    public GameObject[] piecePos;
    public Puzzle puzzle;
    public Transform pieceParent;

    public int piece_no;
    private int pos_no;

    public Vector3 pos;

    void Start()
    {
        string[] str = gameObject.name.Split('_');
        piece_no = int.Parse(str[1]);
        pos = transform.localPosition;
        puzzle.pieceArr.Add(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = mousePosition;
        GetComponent<Image>().raycastTarget = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
        for (int i = 0; i < piecePos.Length; i++)
        {
            if (Vector3.Distance(piecePos[i].transform.position, transform.position) < snapOffset)
            {
                pos_no = piecePos[i].GetComponent<PosSet>().pos_no;
                transform.SetParent(piecePos[i].transform);
                transform.localPosition = Vector3.zero;
                puzzle.CheckedPuzzle(pos_no - 1, piece_no);
            }
        }
    }
    public void RePlace()
    {
        transform.SetParent(pieceParent);
        transform.localPosition = pos;
    }
}
