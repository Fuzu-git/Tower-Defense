using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject standartTurretPrefab;
    private TurretsSerializable _turretToBuild;
    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool HasMoney { get { return PlayerManager.Money >= _turretToBuild.turretCost; } }
    public static BuildManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectTurretToBuild(TurretsSerializable turret)
    {
        _turretToBuild = turret;
    }

    public void BuildTurretOn(Tile tile)
    {
        if (PlayerManager.Money < _turretToBuild.turretCost)
        {
            return; 
        }

        PlayerManager.Money -= _turretToBuild.turretCost;
        GameObject turret = Instantiate(_turretToBuild.prefab, tile.GetBuildPosition(), Quaternion.identity);
        tile._turret = turret;
    }
}
