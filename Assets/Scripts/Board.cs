using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private Graph graph;
    void Start()
    {
        graph = new Graph();
    }

    void Update()
    {
        
    }

    public void connect(int i, int j){
        graph.addEdge(i,j);
    }
    public void VerifyCicle(int vertex) {
        print(graph.findCicles(vertex));
    }
}
