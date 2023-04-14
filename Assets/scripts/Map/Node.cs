using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Vector3 = UnityEngine.Vector3;

public class Node : MonoBehaviour {
    public Color hoverColor;
    public Color busyColor;
    public Color cantPlaceTurret;
    private Color defaultColor;
    public GameObject turretToBuild;
    public GameObject currentTurret;
    public bool canPlace = true;
    public GameObject startNode;
    public GameObject endNode;

    private Renderer rend;

    public void Start() {
        rend = GetComponent<Renderer>();
        if(!canPlace) {
            rend.material.color = cantPlaceTurret;
        } else {
            defaultColor = rend.material.color;
        }
    }
    // Start is called before the first frame update
    void OnMouseEnter() {
        if(canPlace && Builder.instance.getTurretToBuild() != null) {
            if (currentTurret != null) {
                rend.material.color = busyColor;
            }
            else {
                rend.material.color = hoverColor;
            }
        }
    }

    //Recherche de chemin pour les monstres
    public bool CheckPath() {
        UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
        UnityEngine.AI.NavMeshPath path = new UnityEngine.AI.NavMeshPath();
        Debug.Log(UnityEngine.AI.NavMesh.CalculatePath(startNode.transform.position, endNode.transform.position, UnityEngine.AI.NavMesh.AllAreas, path));
        Debug.DrawLine(startNode.transform.position, endNode.transform.position, Color.green);
        return path.status == UnityEngine.AI.NavMeshPathStatus.PathComplete;
    }

    private void OnMouseDown() {
        if(canPlace && currentTurret == null && PlayerStats.playerMoney >= Builder.instance.getCurrentPrice()) {
            CreateTurret();
            PlayerStats.playerMoney -= Builder.instance.getCurrentPrice();
            
        } else if(currentTurret != null) {
            Builder.instance.setCurrentNode(this);
        }
        if(!CheckPath()) {
            DeleteTurret();
        }
    }

    void CreateTurret() {
        Vector3 pos = this.transform.position;
        pos.y += 0.5f;
        turretToBuild = Builder.instance.getTurretToBuild();

        if(turretToBuild != null) {
            this.currentTurret = Instantiate(turretToBuild, pos, this.transform.rotation);
        }
    }
    void DeleteTurret() {
        Destroy(this.currentTurret);
        PlayerStats.playerMoney += Builder.instance.getCurrentPrice();
    }

    void OnMouseExit() {
        if(canPlace) {
            rend.material.color = defaultColor;
        }
    }
}
