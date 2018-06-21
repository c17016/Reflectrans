using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonManager : Photon.MonoBehaviour {

    private GameObject cube;
    private GameObject sphere;
    bool isPlayerType;
    PhotonView m_photonView = null;

    // Use this for initialization
   
        void Start () {
        PhotonNetwork.ConnectUsingSettings(null);
     
		
	}

    void OnJoinedLobby() {
        Debug.Log("ロビーに入りました");

     

        //GameObject.Find("CreateRoomButton").GetComponent<Button>().interactable = true;
    }


    //ルーム入室した時に呼ばれるコールバックメソッド
    void OnJoinedRoom() {
        Debug.Log("ルームへ入室しました。");

        Vector3 initPos = new Vector3(6.34f, 3f, 7.17f);
        if (isPlayerType) {
            cube = PhotonNetwork.Instantiate("Cube", initPos,
                                  Quaternion.Euler(Vector3.zero), 0);
        }
        else {
            sphere = PhotonNetwork.Instantiate("Sphere", initPos,
                                  Quaternion.Euler(Vector3.zero), 0);

        }
    }

    // ルームの入室に失敗すると呼ばれる
    void OnPhotonRandomJoinFailed() {
        Debug.Log("ルームの入室に失敗しました。");

        // ルームがないと入室に失敗するため、ルームがない場合は自分で作る
        PhotonNetwork.CreateRoom("myRoomName");
    }

    public void PlayerRobot() {
        isPlayerType = true;
        // ルームに入室する
        PhotonNetwork.JoinRandomRoom();

    }

    public void PlayerGhost() {
        isPlayerType = false;
        // ルームに入室する
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            //データの送信
            stream.SendNext(isPlayerType);
        }
        else {
            //データの受信
            isPlayerType= (bool)stream.ReceiveNext();
        }
    }
}
