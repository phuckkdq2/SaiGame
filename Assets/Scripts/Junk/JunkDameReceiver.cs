using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class JunkDameReceiver : DamageReceiver
{
    [Header("Junk")]
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if(this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();          
        Debug.Log(transform.name + ": Load Junk Ctrl", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.junkCtrl.JunkDespawn.DespawnObject();

        
    }

    public override void Reborn()
    {
        this.hpMax = this.junkCtrl.JunkSO.hpMax;  // lấy hpMax = hpMax trong JunkSO rồi mới Reborn()
        base.Reborn();    
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }
    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smokeOne;
    }
}
