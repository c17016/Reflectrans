using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCameraTest : MonoBehaviour
{
    
    public Transform targetPlayer;    // 映す対象のTransform    
    public Transform playerDir;       // targetPlayerの方向を向くTransform     
    public GameObject mirrorCamera;   // 鏡のカメラ

    void Update()
    {
        Reflect();        
    }

    // targetPlayer視点の鏡に映像を映す処理
    void Reflect()
    {
        // LookAtでtargetPlayerの方向を見る
        playerDir.transform.LookAt(targetPlayer);
        // print(playerDirection.transform.rotation);

        // mirrorCameraのrotationをplayerDirとは対称の方向に向ける
        mirrorCamera.transform.rotation = new Quaternion(
            0, playerDir.transform.rotation.y * -1, 0, playerDir.transform.rotation.w);
    }

}
