using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoints : SaiMonoBehaviour
{
    [SerializeField] protected List<Transform> points;      // tạo list chứa các point để spawn thiên thạch

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoint();               // load các obj poitn trong obj
    }

    protected virtual void LoadPoint()
    {
        if(this.points.Count > 0) return;
        foreach( Transform point in transform)          // duyệt qua thằng obj đang được gắn component
        {
            this.points.Add(point);                     // thêm các obj point trong obj đã duyệt vào List points
        }
        Debug.Log(transform.name + "LoadPoints", gameObject);  
    }

    public virtual Transform GetRandom()                        // random điểm spawn
    {
        int rand = Random.Range(0 , this.points.Count);     
        return this.points[rand];                               // trả về thằng points[ngẫu nhiên]
    }
   
}
