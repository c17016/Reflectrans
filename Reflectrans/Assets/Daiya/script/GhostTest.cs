using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTest : MonoBehaviour {

 public GameObject button;
    public GameObject Returnbutton;
    GameObject player;
    //Player script;

    bool isPossession = false;
    float time = 3.0f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (isPossession) {
            if (Input.GetKeyDown(KeyCode.W)) {
                transform.Translate(0, 0, 1);
            }
        //    time -= Time.deltaTime;
        //    TimeOver();
        }

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            button.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) {
        print("Exit");
        if (other.gameObject.tag == "Player") {
            button.SetActive(false);
        }
    }

    public void OnClickButton() {
        print("憑依");
        player = GameObject.FindWithTag("Player");
        //script = player.GetComponent<Player>();
        player.SetActive(false);
        //script.possession = true;
        //print(script.possession);
        Returnbutton.SetActive(true);
        button.SetActive(false);
        isPossession = true;
    }

    public void OnClickReturnButton() {
        player.SetActive(true);
        Returnbutton.SetActive(false);
        isPossession = false;

        float x = gameObject.transform.position.x;
        float z = gameObject.transform.position.z;

        player = GameObject.FindWithTag("Player");
        //script = player.GetComponent<Player>();
        //script.Transform(x, z);
        gameObject.transform.position = new Vector3(x, 0, z - 1);

    }

    void TimeOver() {
        if (time < 0) {
            isPossession = false;
            player.SetActive(true);
            Returnbutton.SetActive(false);
            time = 3.0f;

        }
    }

    public void Transform(float x, float z) {
        gameObject.transform.position = new Vector3(x, 0, z - 1);

    }
}
