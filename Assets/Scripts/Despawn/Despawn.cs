using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : SaiMonoBehaviour
{
    protected virtual void FixedUpdate() {
        this.Despawning();
    }

    protected virtual void Despawning()
    {
        if(!CanSpawn()) return; // nếu không thể hủy - > return
        DespawnObject();        // hủy viên đạn
    }

    public virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject); // hủy gameObject cha ( viên đạn )
    }

    protected abstract bool CanSpawn();

}
