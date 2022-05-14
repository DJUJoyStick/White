using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosSet : MonoBehaviour
{
    public int pos_no;

    void Start()
    {
        string[] str = gameObject.name.Split('_');
        pos_no = int.Parse(str[1]);
    }
}
