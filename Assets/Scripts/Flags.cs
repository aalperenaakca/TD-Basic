using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flags : MonoBehaviour
{
    public static Transform[] flags;

    private void Awake()
    {
        flags = new Transform[transform.childCount];
    
        for(int i = 0; i < flags.Length; i++)
        {
            flags[i] = transform.GetChild(i);
        }
    }
}
