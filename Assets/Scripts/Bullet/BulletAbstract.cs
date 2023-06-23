using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAbstract : SaiMonoBehaviour
{
    [Header ("Bullet Abstract")]
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl { get => bulletCtrl;}

    protected override void LoadComponents()
    {
        base.LoadComponents();      
        this.LoadBulletCtrl();          // load component <BulletCtrl>
    }

    protected virtual void LoadBulletCtrl()                            
    {
        if(this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();      // load component <BulletCtrl> từ thằng cha (obj Bullet_1)
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }
}
