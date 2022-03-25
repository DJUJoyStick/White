using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    float fCamSpeed;

    // Start is called before the first frame update
    void Start()
    {
        fCamSpeed = 7.0f;
    }

    void FixedUpdate()
    {
        Vector3 TargetPos = new Vector3(SGameMng.I.PlayerSc.transform.position.x, SGameMng.I.PlayerSc.transform.position.y + 3.5f, -10f);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * fCamSpeed);
    }
}