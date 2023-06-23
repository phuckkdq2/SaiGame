using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    /// <summary>
    /// 
    /// code di chuyển theo <targetPosition>
    /// 
    /// </summary>
    [SerializeField] protected Vector3 targetPosition; // chứa vị trí tọa độ con trỏ chuột
    [SerializeField] protected float speed = 0.01f; // xác định tốc độ di chuyển của con tàu

    private void FixedUpdate()
    {
        this.GetTargetPosition(); //  lấy vị trí tọa độ con trỏ chuột
        this.LookAtTarget();  // nhìn theo con trỏ
        this.Moving();   // Di chuyển
    }

    protected virtual void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos; // lấy vị trí tọa độ con trỏ chuột từ InputManager
        this.targetPosition.z = 0 ; //để đảm bảo đối tượng di chuyển trong một mặt phẳng.
    }

    protected virtual void LookAtTarget()
    {
        Vector3 lookAt = this.targetPosition - transform.parent.position;
        lookAt.Normalize();
        float rot_z = Mathf.Atan2(lookAt.y, lookAt.x)*Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z );


        // Vector3 lookAt = targetPosition;

        // float AngleRad = Mathf.Atan2(lookAt.y - this.transform.parent.position.y, lookAt.x - this.transform.parent.position.x);

        // float AngleDeg = (180 / Mathf.PI) * AngleRad;

        // this.transform.parent.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }

    protected virtual void Moving()   
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.speed);//tính toán vị trí mới của đối tượng 
        transform.parent.position = newPos; // gán vị trí mới cho đối tượng để di chuyển tới vị trí đó.
    }
    

    
}
