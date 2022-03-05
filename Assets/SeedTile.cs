using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ToolAction/Plant Seed")]
public class SeedTile : ToolAction
{
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileReaderController tileReaderController)
    {
        if(tileReaderController.cropsManager.Check(gridPosition) == false)
        {
            return false;
        }

        tileReaderController.cropsManager.Seed(gridPosition);

        return true;
    }

    public override void OnItemUsed(Item usedItem, ItemContainer inventory)
    {
        inventory.Remove(usedItem);
    }
}
