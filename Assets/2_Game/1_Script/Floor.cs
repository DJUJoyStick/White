using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    BoxCollider2D FloorBc;
    public float fJudgment;

    // Start is called before the first frame update
    void Start()
    {
        FloorBc = GetComponent<BoxCollider2D>();
        fJudgment = 0.55f;
    }

    // Update is called once per frame
    void Update()
    {
        CollisionOnOff();
    }

    void CollisionOnOff()
    {
        if (SGameMng.I.PlayerSc.transform.position.y - fJudgment > transform.position.y)
            FloorBc.enabled = true;
        else
            FloorBc.enabled = false;
    }
}
