using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour
{
    SpriteRenderer WaveSr;
    CircleCollider2D WaveCC;

    Vector2 scaleVec;

    // Start is called before the first frame update
    void Start()
    {
        WaveSr = GetComponent<SpriteRenderer>();
        WaveCC = GetComponent<CircleCollider2D>();
        Init();
        StartCoroutine(Wave());
        Destroy(gameObject, 5.0f);
    }

    void Init()
    {
        if (SGameMng.I.nColorCount.Equals(1))
            WaveSr.color = new Color(1.0f, 0.0f, 0.0f);
        else if (SGameMng.I.nColorCount.Equals(2))
            WaveSr.color = new Color(0.0f, 1.0f, 0.0f);
        else if (SGameMng.I.nColorCount.Equals(3))
            WaveSr.color = new Color(0.0f, 0.0f, 1.0f);
    }

    IEnumerator Wave()
    {
        scaleVec = new Vector2(transform.localScale.x + 1.0f, transform.localScale.y + 1.0f);
        transform.localScale = scaleVec;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Wave());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Object"))
        {
            SpriteRenderer sr = col.GetComponent<SpriteRenderer>();
            if (SGameMng.I.nColorCount.Equals(1))
                sr.color = new Color(1.0f, 0.0f, 0.0f);
            else if (SGameMng.I.nColorCount.Equals(2))
                sr.color = new Color(0.0f, 1.0f, 0.0f);
            else if (SGameMng.I.nColorCount.Equals(3))
                sr.color = new Color(0.0f, 0.0f, 1.0f);
        }
    }

}
