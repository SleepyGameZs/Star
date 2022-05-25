using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ToolAction/Plant Seed")]
public class SeedTile : ToolAction
{
    //the toolaction class is other branch of ToolAction scriptable object only for the seeds it checks if the item assigned with "SeedTile" is currently selected and if the current tile 
    //selected is plowed based on cropsManager 
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
