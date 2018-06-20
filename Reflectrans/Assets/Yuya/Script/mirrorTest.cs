using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorTest : MonoBehaviour
{
    public Transform targetPlayer;
    public GameObject playerDirection;
    //public GameObject cameraDirection;

    void Update()
    {
        //Vector3 targetDir = targetPlayer.position - transform.position;

        //playerDirection.transform.rotation = new Quaternion(0, targetDir.y, 0, 0);

        //float angle = Vector3.Angle(targetDir, transform.forward);

        //playerDirection.transform.rotation = Quaternion.Euler(0, angle, 0);
        //print(playerDirection.transform.rotation);




        //float targetDirX = targetPlayer.position.x - transform.position.x;
        //float targetDirY = targetPlayer.position.y - transform.position.y;


        //float radian = Mathf.Atan2(targetDirX, targetDirY);
        //float degree = radian * Mathf.Rad2Deg;
        //lineTransform.eulerAngles = new Vector3(0, 0, degree);             



        playerDirection.transform.LookAt(targetPlayer);
        //print(playerDirection.transform.rotation);

        //cameraDirection.transform.rotation = new Quaternion(
        //    0, playerDirection.transform.rotation.y * -1, 0, playerDirection.transform.rotation.w);

        //playerDirection.transform.rotation = new Quaternion(
        //    0, Mathf.Clamp(playerDirection.transform.rotation.y, -90, 90), 0, playerDirection.transform.rotation.w);




        //var aim = this.targetPlayer.transform.position - transform.position;
        //var look = Quaternion.LookRotation(aim);
        //playerDirecton.transform.localRotation = look; 
    }


}
