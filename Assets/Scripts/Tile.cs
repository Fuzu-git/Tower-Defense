using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color hoverColor;
    private Color _startColor;

    public Vector3 turretOffset;
    private Renderer _rend;

    private GameObject _turret;
    

    private void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
    }

    private void OnMouseEnter()
    {
        _rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }

    private void OnMouseDown()
    {
        if (_turret != null)
        {
            return;
        }

        GameObject turretToBuild = BuildManager.Instance.GetTurretToBuild();
        _turret = Instantiate(turretToBuild, transform.position + turretOffset, transform.rotation);
    }
}
