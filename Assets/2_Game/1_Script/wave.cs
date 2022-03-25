using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour
{
    CircleCollider2D WaveCC;

    // Start is called before the first frame update
    void Start()
    {
        WaveCC = GetComponent<CircleCollider2D>();
        StartCoroutine(Wave());
        Destroy(gameObject, 5.0f);
    }

    IEnumerator Wave()
    {
        WaveCC.radius += 0.5f;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Wave());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Object"))
        {
            SpriteRenderer sr = col.GetComponent<SpriteRenderer>();
            sr.color = new Color(0.0f, 0.0f, 1.0f);
        }
    }

}
