﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public enum BoardState
    {
        BlackVictory, OrangeVictory, Draw, NotFinished
    };
    private Graph graph;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();     
        graph = new Graph();
    }

    // adicionando aresta ao grafo
    public void Connect(int i, int j) {
        graph.addEdge(i,j);
    }

    // removendo aresta do grafo
    public void Disconnect(int i, int j) {

    }

    // verifianco se há ciclo no grafo e acioando colapso se houver
    public bool VerifyCycle(int vertex) {
        if(graph.findCycle(vertex)) {
            gameManager.SetCollapse();
            return true;
        }
        return false;
    }

    // Contando número de campos que já colapsaram
    private int CountCollapsed() {
        int count = 0;
        foreach(Field field in transform.GetComponentsInChildren<Field>()){
            if(field.GetConquerer() != -1){
                count++;
            }
        }
        return count;
    }

    // Verificando vitória, derrota ou jogo não finalizado
    public BoardState GetState() {
        Field[] fields = this.GetComponentsInChildren<Field>();
        int[] points = {0, 0};
        int baseField;
        int field1;
        int field2;
        int field3;
       
        // Verificando colunas
        for( int i = 0; i < 3; i++) {
            baseField = i*3;
            field1 = fields[baseField].GetConquerer();
            field2 = fields[baseField+1].GetConquerer();
            field3 = fields[baseField+2].GetConquerer();
            if(field1 == field2 && field2 == field3 && field1 != -1){
                points[field1]++;
            }
        }

        // Verificando linhas
        for( int i = 0; i < 3; i++) {
            baseField = i;
            field1 = fields[baseField].GetConquerer();
            field2 = fields[baseField+3].GetConquerer();
            field3 = fields[baseField+6].GetConquerer();
            if(field1 == field2 && field2 == field3 && field1 != -1){
                points[field1]++;
            }
        }

        // Verificando diagonal principal
        field1 = fields[0].GetConquerer();
        field2 = fields[4].GetConquerer();
        field3 = fields[8].GetConquerer();
        if(field1 == field2 && field2 == field3 && field1 != -1){
            points[field1]++;
        }

        //Verificando diagonal secundária
        field1 = fields[2].GetConquerer();
        field2 = fields[4].GetConquerer();
        field3 = fields[6].GetConquerer();
        if(field1 == field2 && field2 == field3 && field1 != -1){
            points[field1]++;
        }

        //Verificando se alguem ganhou
        if(points[0] > points[1]) {
            return BoardState.BlackVictory;
        }else if(points[0] < points[1]){
            return BoardState.OrangeVictory;
        }else if(points[0] != 0){
            return BoardState.Draw;
        // se só houver um campo possível de jogar, também é empate
        }else if(CountCollapsed() == 8){
            return BoardState.Draw;
        }else{
            return BoardState.NotFinished;
        }
    }
}
