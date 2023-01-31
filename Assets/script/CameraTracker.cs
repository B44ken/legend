using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour {
    GameObject player;
    float defaultZ;
    void Start() {
        defaultZ = transform.position.z;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        if(player == null) return;

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, defaultZ);
    }
}
