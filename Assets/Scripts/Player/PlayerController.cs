using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : NetworkBehaviour {
    [SerializeField] private Vector3 _movement = new Vector3();

    [Client]
    private void Update() {
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.Space)) {
            Move_cmd();
        }
    }

    [Command]
    private void Move_cmd() {
        MoveClient();
    }

    [ClientRpc]
    private void MoveClient() {
        transform.Translate(_movement);
    } 
}
