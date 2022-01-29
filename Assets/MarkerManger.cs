﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MarkerManger : MonoBehaviour
{
    [SerializeField] Tilemap targetTileMap;
    [SerializeField] TileBase tile;
    public Vector3Int markedCellPosition;
    Vector3Int oldCellPosition;

    private void Update()
    {
        targetTileMap.SetTile(oldCellPosition, null);
        targetTileMap.SetTile(markedCellPosition, tile);
        oldCellPosition = markedCellPosition;
    }
}
