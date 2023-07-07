using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]          // tự add khi gắn component
[RequireComponent(typeof(Rigidbody))]            // tự add khi gắn component

public class BulletImpact : BulletAbstract
{         
          [Header ("Bullet Impact")]
          [SerializeField] protected SphereCollider sphereCollider;       // tạo biến chứa component SphereCollider
          [SerializeField] protected Rigidbody _rigidbody;                // tạo biến chưa component Rigidbody

          protected override void LoadComponents()
          {
                    base.LoadComponents();
                    this.LoadCollider();
                    this.LoadRigidbody();
          }

          protected virtual void LoadCollider()
          {
                    if(this.sphereCollider != null) return;
                    this.sphereCollider = GetComponent<SphereCollider>();          // load component SphereCollider
                    this.sphereCollider.isTrigger = true;                          // set no có thể xuyên qua
                    this.sphereCollider.radius = 0.05f;                            
                    // Debug.Log(transform.name + ": LoadCollider", gameObject);
          }

          protected virtual void LoadRigidbody()
          {
                    if(this._rigidbody != null) return;
                    this._rigidbody = GetComponent<Rigidbody>();                    // load component Rigidbody
                    this._rigidbody.isKinematic = true;                             // set nó không chịu lực hút trái đất
                    // Debug.Log(transform.name + ": LoadCollider", gameObject);
          }

          protected virtual void OnTriggerEnter(Collider other)                 // hàm kiểm tra va chạm 
          {                  
                    if(other.transform.parent == this.bulletCtrl.Shooter) return;

                    this.bulletCtrl.DamageSender.Send(other.transform);
                    // this.createImpactFX(other);
          }

          // protected virtual void createImpactFX(Collider other)
          // {
          //           string fxName = this.GetImpactFX();

          //           Vector3 hitPos = transform.position;
          //           Quaternion hitRos = transform.rotation;
          //           Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRos);
          //           fxImpact.gameObject.SetActive(true);
          // }

          // public virtual string GetImpactFX()
          // {
          //           return FXSpawner.impactOne;
          // }
}
