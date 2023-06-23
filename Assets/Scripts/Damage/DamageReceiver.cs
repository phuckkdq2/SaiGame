using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class DamageReceiver : SaiMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hp = 1;
    [SerializeField] protected int hpMax = 4;
    [SerializeField] protected bool isDead = false;

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected override void OnEnable() {
        this.Reborn();      // khi start thì set hp bằng hp max
    }

    protected override void ResetValue() {
        base.ResetValue();
        this.Reborn();
    }

    protected virtual void LoadCollider()
    {
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>(); 
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.17f;          
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    public virtual void Reborn()
    {
        this.hp = this.hpMax;
        this.isDead = false;
    }

    public virtual void Add(int add)                      // hàm bơm máu
    {
        if(this.isDead) return;
        this.hp += add;
        if(this.hp > this.hpMax) this.hp = this.hpMax;      // khi máu bơm vượt max thì set bằng max chứ không dc quá max
    }

    public virtual void Deduct(int deduct)            // hàm giảm máu (truyền vào tham số nhận giá trị trừ)
    {
        if(this.isDead) return;                       // nếu chết rôi thì không chạy lệnh dưới nữa
        this.hp -= deduct;                            // máu trừ dần theo tham số truyền vào
        if(this.hp < 0) this.hp = 0;                  // khi máu trừ nhỏ hơn 0 thì set về = 0 chứ không dc âm máu
        this.CheckIsDead();
    }

    protected virtual bool IsDead()             // hàm kiểm tra chết hay chưa
    {
        return this.hp <= 0;
    }


    protected virtual void CheckIsDead()
    {
        if(!IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected abstract void OnDead() ;
}
