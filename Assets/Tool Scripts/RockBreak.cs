using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBreak : ToolHit
{
    public override void Hit()
    {
        Destroy(gameObject);
    }
}
