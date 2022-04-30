using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Data/ToolAction/Hoe Tile")]
public class HoeTile : ToolAction
{
    //the toolaction class is a branch of ToolAction scriptable object only for the Hoe it checks if the item assigned with "HoeTile" is currently selected and if the current tile 
    //selected is farmable based on the canPlow TileBase list
    [SerializeField] List<TileBase> canPlow;
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileReaderController tileReaderController, Item item)
    {
        TileBase tileToHoe = tileReaderController.GetTileBase(gridPosition);

        if (canPlow.Contains(tileToHoe) == false)
        {
            return false;
        }

        tileReaderController.cropsManager.Plow(gridPosition);
        return true;
    }
}