using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Photon.MonoBehaviour {

    PhotonView m_photonView = null;

    void Awake() {
        m_photonView = GetComponent<PhotonView>();
    }

    void FixedUpdate() {
        if (!m_photonView.isMine) {
            return;
        }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 v = new Vector3(x, 0, z) * 10f;//適当に調整
            GetComponent<Rigidbody>().AddForce(v);
        
    }
}

