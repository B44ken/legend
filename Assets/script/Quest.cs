using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Quest : MonoBehaviour {

    public GameObject enemy;
    public GameObject boss;
    bool canProceed = true;
    bool dead = false;
    int score = 0;
    int stateID = 0;
    GameObject[] enemies = {};
    TMP_Text toast;

    void Start() {
        toast = GameObject.Find("Toast").GetComponent<TMP_Text>();
    }

    void Update() {
        if(CountEnemies() == enemies.Length) {
            canProceed = true;
        }
        if(Input.GetKeyDown(KeyCode.Return) && canProceed) {
            Proceed();
        }
        UpdateToast();
    }

    void UpdateToast() {
        if(dead) return;

        String text = "Goal: ";
        text += "Kill Enemies ";
        text += "(" + CountEnemies() + " / " + enemies.Length + ")\n";
        if(canProceed) {
            text += "Press Enter to Continue";
        }
        toast.text = text;
    }

    void Proceed() {
        if(!canProceed) return;
        stateID++;
        if(stateID == 1) {
            SpawnEnemies(4, enemy);
            score += 4;
        }
        else if(stateID == 2) {
            SpawnEnemies(1, boss);
            score += 1;
        }
        else {
            int random = UnityEngine.Random.Range(1, 8);
            if(random <= 2) {
                SpawnEnemies(random, boss);
            } else {
                SpawnEnemies(random, enemy);
            }
            score += random;
        }
        canProceed = false;

    }

    int CountEnemies() {
        int count = 0;
        for(int i = 0; i < enemies.Length; i++) {
            if(enemies[i] == null) count++;
        }
        return count;
    }

    void SpawnEnemies(int countInt, GameObject enemy) {
        float count = countInt;
        float spacing = 4f;
        enemies = new GameObject[countInt];
        for(int i = 0; i < count; i++) {
            float x = (i * spacing) - (spacing * (count - 1) / 2);
            enemies[i] = Instantiate(enemy, new Vector3(x, 6, 0), Quaternion.identity);
        }
    }

    public void GameOver() {
        dead = true;
        
        score -= enemies.Length;
        score += CountEnemies();

        toast.text = "Game over! \n Final score: " + score;

        GameObject player = GameObject.Find("Player");
        Destroy(player);

        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.position = new Vector3(1000, 1000, 0);
    }
}
