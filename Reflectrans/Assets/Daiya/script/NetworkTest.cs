using UnityEngine;
using UnityEngine.Networking;
public class NetworkTest : NetworkBehaviour {

    public Canvas canvas;
    public Canvas Networkcanvas;
    public static bool playermode;

    void Start() {
        canvas.gameObject.SetActive(true);
        Networkcanvas.gameObject.SetActive(false);
    }

    public void Robot() {
        playermode = true;
        canvas.gameObject.SetActive(false);
        Networkcanvas.gameObject.SetActive(true);
    }

    public void Ghost() {
        playermode = false;
        canvas.gameObject.SetActive(false);
        Networkcanvas.gameObject.SetActive(true);

    }

    public void OnHostButton() {
        Networkcanvas.gameObject.SetActive(false);
        NetworkManager.singleton.StartHost();

    }

    public void OnClientButton() {
        Networkcanvas.gameObject.SetActive(false);
        NetworkClient client = NetworkManager.singleton.StartClient();
        Debug.Log(client.serverIp);
        Debug.Log(client.serverPort);
        Debug.Log(client.GetType());

    }

    public void OnServerButton() {
        Networkcanvas.gameObject.SetActive(false);
        NetworkManager.singleton.StartServer();
    }
}