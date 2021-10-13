using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static int Money;
    public int startMoney = 40;

    private void Start()
    {
        Money = startMoney;
    }
}
