using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Photon.MonoBehaviour {

    void FixedUpdate() {
        if (photonView.isMine) {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            MoveCube(x, z);
        }
    }
    void MoveCube(float x, float z) {
        Vector3 v = new Vector3(x, 0, z) * 10f;//適当に調整
        GetComponent<Rigidbody>().AddForce(v);
    }
}

