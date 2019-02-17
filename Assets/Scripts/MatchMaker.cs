using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[RequireComponent(typeof(SceneAsyncLoader))]
public class MatchMaker : MonoBehaviourPunCallbacks
{
    AsyncOperation asyncOperation;
    SceneAsyncLoader sceneLoader;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        sceneLoader = GetComponent<SceneAsyncLoader>();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("DefaultRoom", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.IsMessageQueueRunning = false;
        sceneLoader.ChangeScene();
    }
}
