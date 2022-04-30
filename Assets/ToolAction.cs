using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolAction : ScriptableObject
{
    //The script used to assign ScriptableObjects like SeedTile, HoeTile, and etc
    public virtual bool OnApply(Vector2 worldPoint)
    {
        Debug.LogWarning("OnApply isn't implemented");
        return true;
    }

    public virtual bool OnApplyToTileMap(Vector3Int gridPosition, TileReaderController tileReaderController, Item item)
    {
        Debug.LogWarning("OnApplyToTileMap isn't implemented");
        return true;
    }

    public virtual void OnItemUsed(Item usedItem, ItemContainer inventory)
    {

    }
}
