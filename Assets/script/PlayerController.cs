using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Vector3 velocity;
    public float speed = 1.5f;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Vector3 direction = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W)) {
            direction += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S)) {
            direction += new Vector3(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A)) {
            direction += new Vector3(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.D)) {
            direction += new Vector3(0, -speed, 0);
        }
        
        if(direction.magnitude > 0.0f) {
            float rotation = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
            transform.localRotation = Quaternion.Euler(0, 0, rotation);
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
