using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : SaiMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj)     // truyền vào thằng obj cha (trên có 1 cấp)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();    // gán component DamageReceiver từ thằng obj DamageReceiver con
        if(damageReceiver == null) return;                                               // kiểm tra xem damageReceiver component không 
        this.Send(damageReceiver);   
        this.createImpactFX();                                                    // gọi hàm giảm máu của thằng 
    }

    public virtual void Send(DamageReceiver damageReceiver)     // hàm giảm máu 
    {
        damageReceiver.Deduct(this.damage);         // truyền và damage của DamageSender để hàm Deduct của class damageReceiver trừ máu
    }

    protected virtual void createImpactFX()
    {
        string fxName = this.GetImpactFX();

        Vector3 hitPos = transform.position;
        Quaternion hitRos = transform.rotation;
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRos);
        fxImpact.gameObject.SetActive(true);
    }

    public virtual string GetImpactFX()
    {
        return FXSpawner.impactOne;
    }
}
