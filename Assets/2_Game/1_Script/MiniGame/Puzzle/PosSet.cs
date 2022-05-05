using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosSet : MonoBehaviour
{
    public int pos_no;

    // Start is called before the first frame update
    void Start()
    {
        string[] str = gameObject.name.Split('_');
        pos_no = int.Parse(str[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
