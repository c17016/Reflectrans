using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorTest : MonoBehaviour
{
    public Transform targetPlayer;
    public GameObject playerDirection;
    public GameObject cameraDirection;

    void Update()
    {
        playerDirection.transform.LookAt(targetPlayer);
        print(playerDirection.transform.rotation);

        cameraDirection.transform.rotation = new Quaternion(
            0, playerDirection.transform.rotation.y * -1, 0, playerDirection.transform.rotation.w);

        //playerDirection.transform.rotation = new Quaternion(
        //    0, Mathf.Clamp(playerDirection.transform.rotation.y, -90, 90), 0, playerDirection.transform.rotation.w);


        //var aim = this.targetPlayer.transform.position - transform.position;
        //var look = Quaternion.LookRotation(aim);
        //playerDirecton.transform.localRotation = look; 
    }


}
