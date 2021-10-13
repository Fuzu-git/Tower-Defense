using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Tile : MonoBehaviour
{
    public Color hoverColor;
    private Color _startColor;
    public Color noMoney;

    public Vector3 turretOffset;
    private Renderer _rend;

    public GameObject _turret;
    
    BuildManager _buildManager;
    private void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        
        _buildManager = BuildManager.Instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + turretOffset;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!_buildManager.CanBuild)
        {
            return;
        }

        if (_buildManager.HasMoney)
        {
            _rend.material.color = hoverColor;
        }
        else
        { 
            _rend.material.color = noMoney;
        }
        
        
    }

    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (!_buildManager.CanBuild)
        {
            return;
        }
        
        if (_turret != null)
        {
            return;
        }

        _buildManager.BuildTurretOn(this);
    }
}
