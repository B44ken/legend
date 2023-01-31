using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigid;
    Vector3 initialPosition;
    public float speed = 0.8f;
    public float despawnRadius = 20f;
    public float knockStrength = 1;
    
    void Start() {
        player = GameObject.Find("Player");
        rigid = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    Vector3 slide;
    void Update() {
        // rotate towards the player in 2d
        Vector3 toPlayer = player.transform.position - transform.position;
        float anglePlayer = Mathf.Atan2(toPlayer.y, toPlayer.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(anglePlayer, Vector3.forward);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        Vector3 toHome = transform.position - initialPosition;
        if(toHome.magnitude > despawnRadius) {
            rigid.velocity = Vector3.zero;
            transform.position = initialPosition;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "Player") {
            Quest quest = GameObject.Find("EventSystem").GetComponent<Quest>();
            quest.GameOver();
        }
    }


    // void SetPlayerKnockback(GameObject enemy) {
    //     Rigidbody2D playerRigid = enemy.GetComponent<Rigidbody2D>();
    //     Vector3 toPlayer = transform.position - player.transform.position;
    //     toPlayer.Normalize();
    //     Vector3 knock = toPlayer* knockStrength;
    //     playerRigid.velocity = knock;        
    // }
}
