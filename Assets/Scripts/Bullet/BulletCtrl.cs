using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : SaiMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;           // tạo biến damender có kiểu DamageSender
    public DamageSender DamageSender { get => damageSender;}        // cho phép bên ngoài truy cập 

    [SerializeField] protected BulletDespawn bulletDespawn;         // tạo biến bulletDespawn có kiểu BulletDespawn
    public BulletDespawn BulletDespawn { get => bulletDespawn;}     // cho phép bên ngoài truy cập 

    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
    }

    protected virtual void LoadDamageSender()
    {
        if(this.damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<DamageSender>();     // load thằng component<DamageSender> từ thằng obj con DamageSender
    }

    protected virtual void LoadBulletDespawn()
    {
        if(this.bulletDespawn != null) return;
        this.bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();    // load thằng component<BulletDespawn> từ thằng obj con Despawn
    }

    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
