using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardShake : MonoBehaviour
{

    //카메라 흔들기
    public float ShakeAmount;
    float ShakeTime;
    Vector3 initialPosition;

    public void Shake(float time)
    {
        ShakeTime = time;
    }

    public void VibrateBoardForTime(float time)
    {
        ShakeTime = time;
    }

    private void Start()
    {
        initialPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }

    private void Update()
    {
        if (ShakeTime > 0)
        {
            transform.localPosition = Random.insideUnitSphere * ShakeAmount + initialPosition;
            ShakeTime -= Time.deltaTime;
        }
        else
        {
            ShakeTime = 0.0f;
            transform.localPosition = initialPosition;
        }
    }
}
