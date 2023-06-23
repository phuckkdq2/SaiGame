using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false ;  // set trạng thái không bắn 
    [SerializeField] protected float shootDelay = 0.2f; // thời gian chờ bắn
    [SerializeField] protected float shootTimer = 0f; // thời gian bắn dc
    // [SerializeField] protected Transform bulletPrefab; //tạo ra biến chứa object bulletPrefab (đạn)

    private void FixedUpdate() {
        this.Shooting(); // chức năng bắn 
    }

    private void Update() {
        this.IsShhooting();      
    }

    protected virtual void Shooting()
    {
        if(!isShooting) return;             // nếu không bắn => không làm gì 

        this.shootTimer += Time.deltaTime;  // tăng dần thời gian bắn 

        if(this.shootTimer < this.shootDelay) return;       // nếu thời gian bắn < thời gian delay => không chạy                                                          
        this.shootTimer = 0;                                // ngược lại set shootimer = 0 và chạy lệnh dưới (cho phép bắn)

        Vector3 spawPos = transform.position;               // tạo vị trí bắn ( trùng với vị trí tàu hiện tại)
        Quaternion rotation = transform.parent.rotation;    // tạo góc bắn (góc object hướng về)

        // Transform newBullet = Instantiate(this.bulletPrefab, spawPos, rotation); // tạo ra object bulletPrefab(obj viên đạn)
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawPos, rotation);   // spawn đạn (viên đạn số 1) truyền vào tên , vị trí , góc bắn (hàm spawn do mình tự định nghĩa)
        if(newBullet == null) return;

        newBullet.gameObject.SetActive(true); // hiện viên đạn vì trong class Spawner đã ẩn nó ở hàm HidePrefabs();
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);
    }

    protected virtual bool IsShhooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1 ;
        return this.isShooting;
    }
}
