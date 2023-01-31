using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour {
    GameObject player;
    Vector3 knockVector;
    float swingProgress = 0;
    float knockStrength = 8f;
    void Start() {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && swingProgress == -1)
            swingProgress = 0;
        Swing();
    }

    GameObject currentEnemy;
    void OnCollisionEnter2D(Collision2D collision) {
        if(currentEnemy != null)
            return;
        TintHealth health = collision.gameObject.GetComponent<TintHealth>();
        if(health == null)
            return;
        health.Damage(1f);
        SetKnockback(collision.gameObject);
    }

    void SetKnockback(GameObject enemy) {
        Rigidbody2D enemyRigid = enemy.GetComponent<Rigidbody2D>();
        Vector3 toPlayer = enemy.transform.position - player.transform.position;
        toPlayer.Normalize();
        Vector3 knock = toPlayer * knockStrength;
        enemyRigid.velocity = knock;        
    }

    void Swing() {
        if(swingProgress == -1) {
            return;
        } else if(swingProgress >= 1) {
            swingProgress = -1;
            transform.localPosition = new Vector3(0, 0, 100000);
            return;
        }

        float rotate = (swingProgress - 0.5f) * 2.0f;
        float height = 0.5f;
        transform.localRotation = Quaternion.Euler(0, 0, -rotate * 20f);
        transform.localPosition = new Vector3(Mathf.Sin(height * rotate * 20f / 45f), Mathf.Cos(height * rotate * 20f / 45f), 0);
        swingProgress += Time.deltaTime * 2.0f;
    }
}
