using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;   // tạo biến bulletCtrl kiểu BulletCtrl

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if(this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();     // load thằng componrnt BulletCtrl được gắn vào thằng cha Bullet_1
        Debug.Log(transform.name + ": Load Bullet Ctrl", gameObject);
    }

    public override void Send(DamageReceiver damageReceiver)     // ghi đè thêm thằng Hàm gửi Dame từ lớp kế thừa
    {
        base.Send(damageReceiver);
        this.DespawnObject();                                   // gọi hàm Despawn thằng bullet
    }

    protected virtual void DespawnObject()          // hàm Despawn bullet
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }
}
