using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Builder : MonoBehaviour {

    public static Builder instance;
    private int currentPrice;
    private GameObject turretToBuild;
    public GameObject waterTurretPrefab;
    public GameObject fireTurretPrefab;
    public GameObject iceTurretPrefab;
    public Node currentNode;
    public NodeUI nodeUI;

    private void Awake() {
        if (instance != null) {
            return;
        }
        instance = this; 
    }

    void Start() {
        turretToBuild = waterTurretPrefab;
        currentPrice = 1000;
    }

    public GameObject getTurretToBuild() {
        return turretToBuild;
    }

    public void setCurrentNode(Node node) {
        this.turretToBuild = null;
        this.currentNode = node;
        nodeUI.SetTarget(node);
    }

    public void setTurretToBuild(GameObject turret) {
        
        this.turretToBuild = turret;
        this.currentNode = null;
        nodeUI.Hide();
    }

    public void setCurrentPrice(int price) {
        this.currentPrice = price;
    }

    public int getCurrentPrice() {
        return this.currentPrice;
    }
}
