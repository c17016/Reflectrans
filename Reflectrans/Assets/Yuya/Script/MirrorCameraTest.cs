using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCameraTest : MonoBehaviour
{
    public Transform player;
    public Transform mirrorCamera;
    private Vector3 lookTarget;
    private Vector3 newLook;
    private float dist;

    void Start()
    {
        //   lookTarget = mirrorCamera.position + new Vector3(0, 0, 4); 
        lookTarget = mirrorCamera.position + (mirrorCamera.right);
        newLook = lookTarget;
    }
    void Update()
    {
        newLook.x = lookTarget.x - (player.position.x - mirrorCamera.position.x);
        mirrorCamera.LookAt(newLook, Vector3.up);

        dist = Vector3.Distance(player.transform.position, mirrorCamera.transform.position);
        mirrorCamera.GetComponent<Camera>().fieldOfView = 80 - (dist * 2);
    }




    //float diffX = toX - fromX;
    //float diffY = toY - fromY;

    //float radian = Mathf.Atan2(diffY, diffX);
    //float degree = radian * Mathf.Rad2Deg;
    //lineTransform.eulerAngles = new Vector3(0, 0, degree);         





    //public Transform target;    

    //void Update()
    //{
    //    Vector3 targetDir = target.position - transform.position;
    //    float angle = Vector3.Angle(targetDir, transform.forward);

    //    //if (angle < 5.0f)
    //    //    print("close");

    //    transform.rotation = Quaternion.Euler(transform.rotation.x, angle, transform.rotation.z);
    //}




    //public Transform player;
    //public Transform mirrorCamera;
    //private Vector3 lookTarget;
    //private Vector3 newLook;
    //private float dist;

    //void Start()
    //{
    //    //   lookTarget = mirrorCamera.position + new Vector3(0, 0, 4); 
    //    lookTarget = mirrorCamera.position + (4 * mirrorCamera.right);
    //    newLook = lookTarget;
    //}
    //void Update()
    //{
    //    newLook.x = lookTarget.x - (player.position.x - mirrorCamera.position.x);
    //    mirrorCamera.LookAt(newLook, Vector3.up);

    //    dist = Vector3.Distance(player.transform.position, mirrorCamera.transform.position);
    //    mirrorCamera.GetComponent<Camera>().fieldOfView = 80 - (dist * 2);
    //}
}
