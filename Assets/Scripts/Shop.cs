using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;
    public TurretsSerializable turret;
    
    public void Start()
    {
        _buildManager = BuildManager.Instance;
    }

    public void SelectTurret()
    {
        _buildManager.SelectTurretToBuild(turret);
    }
}
