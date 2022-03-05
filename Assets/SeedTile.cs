using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ToolAction/Plant Seed")]
public class SeedTile : ToolAction
{
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileReaderController tileReaderController, Item item)
    {
        if(tileReaderController.cropsManager.Check(gridPosition) == false)
        {
            return false;
        }

        tileReaderController.cropsManager.Seed(gridPosition, item.crop);

        return true;
    }

    public override void OnItemUsed(Item usedItem, ItemContainer inventory)
    {
        inventory.Remove(usedItem);
    }
}
