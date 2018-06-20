using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class PlayerTest : NetworkBehaviour {

    Text text;
    public GameObject cube;

    private static System.DateTime startTime;

    // Use this for initialization
    void Start() {
        int rand = Random.Range(-25, 25);
        transform.position = new Vector3(rand, 0.5f, rand);
        

    }


    public override void OnStartLocalPlayer() {
        Debug.Log("SphereScript::OnstartLocalPlayer");
        base.OnStartLocalPlayer();
        Renderer r = GetComponent<Renderer>();
        Color c = Color.red;
        r.material.color = c;
    }

    // Update is called once per frame
    void Update() {
        if (isServer) {
            Count();
        }

        if (isLocalPlayer) {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.Space)) { CmdSpawnIt(); }

        if (gameObject.transform.position.y <= 0) {
            gameObject.transform.position = new Vector3(0, 0.5f, 0);
        }
    }



    [ServerCallback]
    void Count() {
        if (!isServer) { return; }
        int count = (int)((System.DateTime.Now - startTime).TotalSeconds);
        RpcSetCount(count);
    }

    [ClientRpc]
    void RpcSetCount(int n) {
        if (text != null) {
            text.text = "Client:" + n;
        }
    }

    [ClientCallback]
    void Move() {
        if (!isLocalPlayer) { return; }
        //Main Cameraの位置の調整
        Vector3 v = transform.position;
        v.z -= 10;
        v.y += 3;
        Camera.main.transform.position = v;

    }

    [ClientCallback]
    void FixedUpdate() {
        if (!isLocalPlayer) { return; }
        if (NetworkTest.playermode) {
            print("ROBOT");
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            CmdMoveSphere(x, z);
        }
        else {
            print("GHOST");
        }

    }
    //Sphereの移動
    [Command]
    public void CmdMoveSphere(float x, float z) {
        Vector3 v = new Vector3(x, 0, z) * 10f;//適当に調整
        GetComponent<Rigidbody>().AddForce(v);
    }

    [Command]
    void CmdSpawnIt() {
        Debug.Log("spawned.");
        GameObject obj = Instantiate(cube, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z),
            Quaternion.Euler(new Vector3(0, 0, 0)));

        NetworkServer.Spawn(obj);
        Rigidbody r = obj.GetComponent<Rigidbody>();
        Vector3 v = Camera.main.transform.forward;
        v.y += 1f;
        r.AddForce(v * 1000);
        r.AddTorque(new Vector3(10f, 0f, 10f) * 100);
    }
}


