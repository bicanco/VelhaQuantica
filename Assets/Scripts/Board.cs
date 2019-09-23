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
    public void VerifyCicle() {
        // for(int i = 0 ; i < 9; i++){
        //     for(int j= 0 ;j <9; j++){
        //         print(i);
        //         print(j);
        //         print(graph.graph[i,j]);
        //     }
        // }
    }
}
