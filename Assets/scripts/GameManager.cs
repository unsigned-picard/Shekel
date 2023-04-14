using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using TMPro;

public class GameManager : MonoBehaviour {

    public static bool isGameOver;
    public GameObject GameOverUI;
    public TextMeshProUGUI wavesText;
    // Start is called before the first frame update
    void Start() {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update() {
        
        if(isGameOver) {
            EndGame();
            return;
        }
        if(PlayerStats.playerLife <= 0) {
            PlayerStats.playerLife = 0;
            isGameOver = true;
            EndGame();
        }
    }

    public void EndGame(){
        this.GameOverUI.SetActive(true);
        this.wavesText.text = "You have survived " + (PlayerStats.playerWaves - 1) + " waves !";
    }

    public void StartNewGame() {
        isGameOver = false;
        this.GameOverUI.SetActive(false);
        PlayerStats.playerLife = 20;
        PlayerStats.playerMoney = 10000;
        PlayerStats.playerWaves = 0;

        GameObject[] turrets = GameObject.FindGameObjectsWithTag("turret");
        foreach(GameObject turret in turrets) {
            Destroy(turret);
        }
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("monster");
        foreach (GameObject monster in monsters) {
            Destroy(monster);
        }
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("node");
        foreach (GameObject node in nodes){
            Node n = node.GetComponent<Node>();
            if(n != null)
                n.currentTurret = null;
        }
    }

    public void QuitGame() {
        Application.Quit();
    }
}
