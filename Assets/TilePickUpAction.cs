using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ToolAction/Harvest")]
public class NewBehaviourScript : ToolAction
{
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileReaderController tileReaderController, Item item)
    {
        tileReaderController.cropsManager.PickUp(gridPosition);

        return true;
    }
}
