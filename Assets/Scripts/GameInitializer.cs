using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameInitializer : MonoBehaviour
{
    void Start()
    {
        PhotonNetwork.IsMessageQueueRunning = true;

        Vector3 position = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        PhotonNetwork.Instantiate("NetworkPlayer", position, Quaternion.identity);
    }
}
