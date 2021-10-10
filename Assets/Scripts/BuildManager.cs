using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject standartTurretPrefab;
    private GameObject turretToBuild;

    public static BuildManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        turretToBuild = standartTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
