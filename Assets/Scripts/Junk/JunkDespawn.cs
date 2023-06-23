using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDespawn : DespawnByDistance
{
    public override void DespawnObject() // ghi đè lại thằng DespawnObject của Despawn
    {
        JunkSpawner.Instance.Despawn(transform.parent);             // gọi thằng Despawn trong Spawner vì JunkSpawner kế thừa từ Spawner
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 25f;       // ghi đè lại để giới hạn thằng thiên thạch đi đến 25f thì được despawn 
    }
}
