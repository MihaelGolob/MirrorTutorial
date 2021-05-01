using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : NetworkBehaviour {
    // variables synced between server and client
    [SyncVar(hook = nameof(OnHelloCountChange))] private int helloCount = 0;
    
    private void HandleMovement() {
        // Check if the script is running on the local player (we cant control other players)
        if (isLocalPlayer) {
            float moveHorizontal = Input.GetAxis("Horizontal") * 0.1f;
            float moveVertical = Input.GetAxis("Vertical") * 0.1f;

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
            transform.position += movement;
        }
    }

    private void Update() {
        HandleMovement();

        if (isLocalPlayer && Input.GetKeyDown(KeyCode.X)) {
            Debug.Log("Sending Hello message to server");
            Hello();
        }
    }

    public override void OnStartServer() {
        base.OnStartServer();
        Debug.Log("Player has been spawned on the server");
    }

    [Command]
    private void Hello() {
        Debug.Log("Received Hello from CLIENT");
        helloCount++;
        ReplyHello();
    }

    [TargetRpc]
    private void ReplyHello() {
        Debug.Log("Received Hello from SERVER");
    }

    [ClientRpc]
    private void TooHigh() {
        Debug.Log("Player too high!");
    }
    
    void OnHelloCountChange(int oldc, int newc) {
        Debug.Log($"We had {oldc} hellos, now we have {newc} hellos");
    }
}
