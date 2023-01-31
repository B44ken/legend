using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TintHealth : MonoBehaviour {
    SpriteRenderer render;
    public float startHealth = 4;
    float health;

    void Start() {
        render = GetComponent<SpriteRenderer>();
        health = startHealth;
    }

    void Update() {
    }

    public void Damage(float amount) {
        health -= amount;
        float red = health / startHealth;
        render.color = new Color(1, red, red, 1);
        if(health <= 0) Destroy(gameObject);
    }
}