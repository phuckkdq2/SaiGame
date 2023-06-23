using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    public override void DespawnObject() // ghi đè lại thằng DespawnObject của Despawn
    {
        BulletSpawner.Instance.Despawn(transform.parent);    // gọi hàm Despawn từ Spawner
    }
}
