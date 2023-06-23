using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn // kế thừa từ despawn 
{
    
    [SerializeField] protected float disLimit = 70f; // vị trí giới hạn
    [SerializeField] protected float distance = 0f; // khoảng cách viên đạn di chuyển
    [SerializeField] protected Transform mainCam; // camera


    protected override void LoadComponents()
    {
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if(this.mainCam != null) return;
        this.mainCam = Transform.FindObjectOfType<Camera>().transform;
    }


    protected override bool CanSpawn()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCam.position); // vị trí từ viên đạn - camera 
        if(this.distance > this.disLimit) return true;
        return false;
    }
}
