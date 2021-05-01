using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager {
    // Some overrides of the callbacks in the network manager
    public override void OnStartServer() {
        base.OnStartServer();
        Debug.Log("Server started");
    }

    public override void OnStopServer() {
        base.OnStopServer();
        Debug.Log("Server stopped");
    }

    public override void OnClientConnect(NetworkConnection conn) {
        base.OnClientConnect(conn);
        Debug.Log("Connected to server");
    }

    public override void OnClientDisconnect(NetworkConnection conn) {
        base.OnClientConnect(conn);
        Debug.Log("Disconnected from server");
    }
}
