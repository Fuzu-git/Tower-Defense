using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] Pins;

    private void Awake()
    {
        Pins = new Transform[transform.childCount];
        for (int i = 0; i < Pins.Length; i++)
        {
            Pins[i] = transform.GetChild(i);
        }
    }
}
