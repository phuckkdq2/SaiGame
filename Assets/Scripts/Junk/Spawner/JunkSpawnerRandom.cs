using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : SaiMonoBehaviour
{
     [Header("Junk Random")]
     [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;   // tạo biến hứng component JunkSpawnerCtrl
     [SerializeField] protected float timerDelay = 1f;            // thời gian delay trước khi random spawn
     [SerializeField] protected float randomTimer = 0f;            
     [SerializeField] protected float randomLimit = 9f;            // giới hạn số lượng spawn

     protected override void LoadComponents()
     {
          base.LoadComponents();
          this.LoadJunkSpawnerCtrl();          // load component JunkSpawnerCtrl
     }

     protected virtual void LoadJunkSpawnerCtrl()      // auto gán thằng component junkSpawnerCtrl vào 
     {
          if(this.junkSpawnerCtrl != null) return;
          this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
     }

     protected virtual void FixedUpdate() {
          this.JunkSpawning();          // spawn thiên thạch 
     }


     protected virtual void JunkSpawning()
     {
          if(this.RandomReachLimit()) return;                                        // nếu số lượng spawn >= số lượng spawn giới hạn thì không làm gì

          this.randomTimer += Time.fixedDeltaTime;                                   // tăng dần biến randomTime
          if(this.randomTimer < timerDelay) return;                                 // nêu randomTime < timerDelay thì không làm gì 
          this.randomTimer = 0;                                                     // nếu randomTimer chạy qua timerDelay đưa biến randomTimer về 0 rồi thực hiện những câu lệnh bên dưới

          Transform randPoint = this.junkSpawnerCtrl.SpawnPoints.GetRandom();            // random điểm spawn
          Vector3 pos = randPoint.position;                                              // lấy vị trí của randPoint
          Quaternion rot = transform.rotation;                                           // lấy giá trị hướng quay 

          Transform prefab = this.junkSpawnerCtrl.JunkSpawner.RandomPrefabs();          // gọi hàm lấy random thằng junk trong list prefbas và gắn nó vào biến prefab

          Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(prefab , pos , rot);   // spawn thiên thạch theo vị trí và góc quay tương ứng rồi gán nó vào biến obj
          obj.gameObject.SetActive(true);                                               // set để junk hiển thị trên scene vì những thằng trong frefabs đã bị ẩn từ đầu rồi
          
     }

     protected virtual bool RandomReachLimit()                                  // 
     {
          int currentJunk = this.junkSpawnerCtrl.JunkSpawner.SpawnerCount;      // biến hứng giá trị biến đếm spawn (số lượng spawn)
          return currentJunk >= this.randomLimit;                               // trả về số lượng spawn >= số lượng spawn giới hạn
     }
}
