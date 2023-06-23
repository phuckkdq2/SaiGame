using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : SaiMonoBehaviour // kế thừa SaiMonoBehaviour
{

    [SerializeField] protected List<Transform> perfabs; // tạo list prefabs chưa viên đạn
    [SerializeField] protected List<Transform> poolObjs; // list chứa viên đạn bị hủy 
    [SerializeField] protected Transform holder;         // tạo tra để quản lí máy cái spawn ra
    [SerializeField] protected int spawnerCount = 0;     // tạo bộ đếm khi spawn
    public int SpawnerCount { get => spawnerCount;}

    protected override void LoadComponents()  // vì đc kế thừa từ thg SaiMonoBehavior nên dc gọi đầu tiên vì trong Awake()
    {
        this.LoadPrefabs(); // duyệt qua thằng obj Prefabs
        this.LoadHolder();  // tự động tìm obj Holder gắn vào
    }

    protected virtual void LoadHolder()
    {
        if(this.holder != null) return;             // nếu Holder được gắn vào thì thôi
        this.holder = transform.Find("Holder");     // nếu chưa thì tìm obj có tên holder rồi gán nó vào 
    }

    protected virtual void LoadPrefabs()
    {
        if(this.perfabs.Count >0 ) return;      // nếu thằng list perfabs > 0 thì kh làm gì cả

        Transform prefabObj = transform.Find("Prefabs");   // tìm object có tên là Prefabs gán vào biến prefabObj dạng Trasnform
        foreach(Transform prefab in prefabObj)    // lặp qua các phần tử của thằng Objcet Prefabs
        {   
            this.perfabs.Add(prefab);   // thêm prefab vào list prefabs
        }

        this.HidePrefabs(); // ẩn các thằng đã Add

        Debug.Log(transform.name + "LoadPrefabs", gameObject );

    }

    protected virtual void HidePrefabs()
    {
        foreach(Transform prefab in this.perfabs)  // duyệt qua thằng list prefabs
        {
            prefab.gameObject.SetActive(false); // ẩn nó đi 
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawPos, Quaternion rotation)   // Spawn với tham số truyền vào là string
    {
        Transform prefab = this.GetPrefabByName(prefabName);            // lấy tên prefab 
        if(prefab == null){                                             // nếu không có prefab thì không trả về gì 
            Debug.LogWarning("prefab not found !" + prefabName);
            return null;
        }
        // Transform newPrefab = Instantiate(prefab, spawPos, rotation); // tạo ra object (obj viên đạn)
        // return newPrefab;

        return Spawn(prefab, spawPos, rotation);                        // spawn thằng prefab được xử lí ở hàm Spawn() bên dưới
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawPos, Quaternion rotation)   // Spawn với tham số truyền vào là obj
    {
        Transform newPerfab = this.GetObjectformPool(prefab);        // tạo ra obj mới hoặc lấy lại từ thằng list pool
        newPerfab.SetPositionAndRotation(spawPos, rotation);        // set lại vị trí obj (không cần biết lấy trong pool hay được new ra)

        newPerfab.parent = this.holder;                             // đưa vào holder (bằng cách (tên.parent) )
        this.spawnerCount++;                                        // tăng biến đếm spawn
        return newPerfab;
    }

    protected virtual Transform GetObjectformPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs) // lặp qua list poolObjs 
        {
            if(poolObj.name == prefab.name){          // kiểm tra xem trong poolObjs có obj nào giống tên (có bản sao) hay chưa
                this.poolObjs.Remove(poolObj);        // bỏ objs đó ra khỏi list poolObjs
                return poolObj;                       // trả về obj đó để chuẩn bị tái sử dụng(spawn)  
            }
        }
    
        // nếu duyệt qua hết trong list poolObjs mà không còn nữa
        Transform newPerfab = Instantiate(prefab);      // tạo mới obj
        newPerfab.name = prefab.name;                   // set tên của thằng prefab vừa tạo bằng tên của thằng prefab truyền vào (có sẵn) để đồng bộ
        return newPerfab;                               // trả về thằng vừa được tạo để mang đi spawn
    }

    public virtual Transform GetPrefabByName(string prefabName){
        foreach(Transform prefab in this.perfabs){          // duyejt qua list prefabs
            if(prefabName == prefab.name) return prefab;    // nếu tên prefabs truyền vào trùng tên frebas trong list thì trả về nó
        }
        return null;
    }

    public virtual void Despawn(Transform obj)  // hàm Desawn
    {
        this.poolObjs.Add(obj);                 // đưa cái objs trở vào thằng List pool
        obj.gameObject.SetActive(false);        // disable nó đi
        this.spawnerCount-- ;                   // giảm biến đếm spawn
    }

    public virtual Transform RandomPrefabs()                // chọn random 1 thằng trong list prefabs
    {
        int rand = Random.Range(0 , this.perfabs.Count);
        return this.perfabs[rand];                          // trả về thằng trong list được random ra     
    }       
}
