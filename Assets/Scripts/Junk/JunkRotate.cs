using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRotate : JunkAbstract
{
    [SerializeField] protected float speed = 40f;     // tốc độ quay

    protected virtual void FixedUpdate() {
        this.Rotating();                // gọi hàm xuoay thiên thạch
    }

    protected virtual void Rotating()
    {
        Vector3 eulers = new Vector3(0, 0, 1);                                   // tạo góc quay z
        this.junkCtrl.Model.Rotate(eulers * this.speed * Time.fixedDeltaTime);      // quay model (hình ảnh) theo góc z
    }
}
