using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;

    public float moveSpeed;
    public Joystick joystick;
    public Camera playerCamera;
    public Image searchLight;
    float lightColor;
    GameObject ghost;

    float color_a;
    bool flag_a;
    Color change_color;


    void Start()
    {  
        rb = GetComponent<Rigidbody>();
        //lightColor = searchLight.GetComponent<Image>().color.a;
        ghost = GameObject.FindGameObjectWithTag("Ghost");          
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        Distance();
    }

    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(playerCamera.transform.forward, new Vector3(1, 0, 1)).normalized;

//#if UNITY_EDITOR
//        Debug.Log("Unity Editor");
//        Vector3 moveForward = cameraForward * inputVertical + playerCamera.transform.right * inputHorizontal;

//#else
        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * joystick.Vertical + playerCamera.transform.right * joystick.Horizontal;

//#endif

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed /*+ new Vector3(0, rb.velocity.y, 0)*/;

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

    void Distance()
    {
        float dis = Vector3.Distance(transform.position, ghost.transform.position);
        //print(dis);

        if (dis < 10)
        {
            change_color = new Color(255, 0, 0, color_a);              
        }
        else if (dis < 20)
        {
            change_color = new Color(255, 255, 0, color_a); 
        }
        else
        {
            change_color = new Color(0, 255, 0, color_a);
        }

        SearchLight(change_color);  
    }

    void SearchLight(Color change)
    {
        searchLight.color = change;

        if (flag_a)
            color_a -= Time.deltaTime;
        else
            color_a += Time.deltaTime;

        if (color_a < 0)
        {
            color_a = 0;
            flag_a = false;
        }
        else if (color_a > 1)
        {
            color_a = 1;
            flag_a = true;
        }

    }   
}
