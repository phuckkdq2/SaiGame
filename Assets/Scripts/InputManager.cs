using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance; // cho phép truy cập dễ dàng và chia sẻ thông tin giữa các thành phần khác nhau trong chương trình.
    public static InputManager Instance { get => instance;  }

    [SerializeField] protected Vector3 mouseWorldPos; // chứa vị trí tọa độ con trỏ chuột
    public Vector3 MouseWorldPos { get => mouseWorldPos; }

    [SerializeField] protected float onFiring;
    public float OnFiring { get => onFiring; }


    // ta có thể truy cập đối tượng "InputManager" từ bất kỳ đâu trong chương trình thông qua việc gọi "InputManager.instance".
    private void Awake() 
    {
        InputManager.instance = this;
    }

    private void Update() {
        this.GetMouseDown();
    }

    private void FixedUpdate()
    {
       this.GetMousePos();    // lấy vị trí tọa độ con trỏ chuột  
    }

    protected virtual void GetMousePos() // virtual cho phép ghi đè 
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // lấy vị trí tọa độ con trỏ chuột
    }

    protected virtual void GetMouseDown(){
        this.onFiring = Input.GetAxis("Fire1");
    }
}
