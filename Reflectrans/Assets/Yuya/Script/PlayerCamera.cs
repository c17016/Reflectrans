using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCamera : MonoBehaviour
{
    public GameObject targetObj;
    Vector3 targetPos;

    void Start()
    {
        //targetObj = GameObject.Find("TargetGameObject");
        targetPos = targetObj.transform.position;
    }

    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        // マウスの右クリックを押している間
        if (Input.GetMouseButton(1))
        {
            // マウスの移動量
            float mouseInputX = Input.GetAxis("Mouse X");
            //float mouseInputY = Input.GetAxis("Mouse Y");
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);
            // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
            //transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 200f);
        }

    }



    //// 回転速度
    //public float rotateSpeed = 5.0f;
    //// 移動速度
    //public float moveSpeed = 0.5f;

    //void Update()
    //{
    //    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
    //    {
    //        if (EventSystem.current != null)
    //        {
    //            // UIを最初に触った場合はタッチでの操作をさせない
    //            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
    //            {
    //                return;
    //            }
    //        }

    //        // タッチ数で処理を変える
    //        if (Input.touchCount == 1)
    //        {
    //            // タッチ数が1つの場合の処理

    //            // タッチを取得
    //            Touch touch = Input.GetTouch(0);

    //            // 画面を横にスワイプしたら親オブジェクトをY軸で回転させる
    //            this.transform.parent.gameObject.transform.Rotate(0, touch.deltaPosition.x * rotateSpeed, 0);

    //            // 画面を縦にスワイプしたらカメラをY軸で移動させる
    //            this.transform.position += new Vector3(0, -touch.deltaPosition.y * moveSpeed / 10, 0);
    //        }
    //        else if (Input.touchCount == 2)
    //        {
    //            // タッチ数が2つの場合の処理

    //            // タッチを取得
    //            Touch touchZero = Input.GetTouch(0);
    //            Touch touchOne = Input.GetTouch(1);

    //            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
    //            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

    //            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
    //            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

    //            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

    //            // ピンチ操作時はカメラの距離を変える
    //            this.transform.localPosition += new Vector3(0, 0, deltaMagnitudeDiff * moveSpeed / 10);
    //        }
    //    }
    //}
}
