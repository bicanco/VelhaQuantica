using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Graph graph;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();     
        graph = new Graph();
    }

    void Update()
    {
        
    }

    public void connect(int i, int j) {
        graph.addEdge(i,j);
    }
    public void VerifyCycle(int vertex) {
        if(graph.findCycles(vertex)) {
            gameManager.SetCollapse();
        }
    }
}
