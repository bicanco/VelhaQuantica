using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public enum BoardState
    {
        BlackVictory, OrangeVictory, Draw, NotFinished
    };
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
        if(graph.findCycle(vertex)) {
            gameManager.SetCollapse();
        }
    }

    public BoardState GetState() {
        Field[] fields = this.GetComponentsInChildren<Field>();
        int[] points = {0, 0};
        int baseField;
        int field1;
        int field2;
        int field3;
        for( int i = 0; i < 3; i++) {
            baseField = i*3;
            field1 = fields[baseField].GetConquerer();
            field2 = fields[baseField+1].GetConquerer();
            field3 = fields[baseField+2].GetConquerer();
            if(field1 == field2 && field2 == field3 && field1 != -1){
                points[field1]++;
            }
        }
        for( int i = 0; i < 3; i++) {
            baseField = i;
            field1 = fields[baseField].GetConquerer();
            field2 = fields[baseField+3].GetConquerer();
            field3 = fields[baseField+6].GetConquerer();
            if(field1 == field2 && field2 == field3 && field1 != -1){
                points[field1]++;
            }
        }
        field1 = fields[0].GetConquerer();
        field2 = fields[4].GetConquerer();
        field3 = fields[8].GetConquerer();
        if(field1 == field2 && field2 == field3 && field1 != -1){
            points[field1]++;
        }
        field1 = fields[2].GetConquerer();
        field2 = fields[4].GetConquerer();
        field3 = fields[6].GetConquerer();
        if(field1 == field2 && field2 == field3 && field1 != -1){
            points[field1]++;
        }
        if(points[0] > points[1]) {
            return BoardState.BlackVictory;
        }else if(points[0] < points[1]){
            return BoardState.OrangeVictory;
        }else if(points[0] != 0){
            return BoardState.Draw;
        }else{
            return BoardState.NotFinished;
        }
    }
}
