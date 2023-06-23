using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : SaiMonoBehaviour
{
    
    [SerializeField] protected float moveSpeed = 1 ; // tốc đọ di chuyển 
    [SerializeField] protected Vector3 direction = Vector3.right; // hướng bay 

    private void Update() {
        transform.parent.Translate(this.direction * this.moveSpeed *Time.deltaTime); // hàm di chuyển
    }
}
 