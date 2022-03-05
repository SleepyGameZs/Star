using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Data/ToolAction/Hoe Tile")]
public class HoeTile : ToolAction
{
    [SerializeField] List<TileBase> canPlow;
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileReaderController tileReaderController)
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
