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
        this.Send(damageReceiver);                                                       // gọi hàm giảm máu của thằng 
    }

    public virtual void Send(DamageReceiver damageReceiver)     // hàm giảm máu 
    {
        damageReceiver.Deduct(this.damage);         // truyền và damage của DamageSender để hàm Deduct của class damageReceiver trừ máu
    }

    
}
