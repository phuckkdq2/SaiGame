using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class ItemLooter : SaiMonoBehaviour
{
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected SphereCollider _coliider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
          base.LoadComponents();
          LoadInventory();
          LoadRigidbody();
          LoadTrigger();
    }

    protected virtual void LoadInventory()
    {
          if(this.inventory != null) return;
          this.inventory = transform.parent.GetComponent<Inventory>();
    }

    protected virtual void LoadTrigger()
    {
          if(this._coliider != null) return;
          this._coliider = transform.GetComponent<SphereCollider>();
          this._coliider.isTrigger = true;
          this._coliider.radius = 0.3f; 
    }

    protected virtual void LoadRigidbody()
    {
          if(this._rigidbody != null) return;
          this._rigidbody = transform.GetComponent<Rigidbody>();
          this._rigidbody.useGravity = false;
          this._rigidbody.isKinematic = true;
    }

    protected virtual void OnTriggerEnter(Collider other) 
    {
         ItemPickupable itemPickupable = other.GetComponent<ItemPickupable>();
         if(itemPickupable == null) return;
         Debug.Log(other.name);
         Debug.Log(other.transform.parent.name);
    }
}
