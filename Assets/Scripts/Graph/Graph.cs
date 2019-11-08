using System.Collections;
using System.Collections.Generic;

public class Graph
{
    // Número de vértices
    private int N;
    // Lista de adjacências
    private List<int>[] graph;

    // Inicialização do grafo não orientado
    public Graph(int size = 9){
        N = size;
        graph = new List<int>[size];
        for(int i = 0; i < size; i++){
            graph[i] = new List<int>();
        }
    }

    // Adicionando aresta às listas de adjacências
    public void addEdge(int vertex1, int vertex2){
        graph[vertex1].Add(vertex2);
        graph[vertex2].Add(vertex1);
    }

    // Removendo aresta das listas de adjacências
    public void removeEdge(int vertex1, int vertex2){
        graph[vertex1].Remove(vertex2);
        graph[vertex2].Remove(vertex1);
    }

    // busca em profundidade no grafo para identificar ciclos
    private bool dfs(int v, bool[] visited, int parent){
        visited[v] = true;

        foreach (int item in graph[v])
        {
            if(visited[item] == false){
                if(dfs(item,visited,v)){
                    return true;
                }
            } else if( parent != item){
                return true;
            }
        }

        return false;
    }

    // detectando um ciclo que contenha o vértice passado
    public bool findCycle(int vertex){
        bool[] visited = new bool[N];
        for(int i = 0; i < N; i++){
            visited[i] = false;
        }
        return dfs(vertex, visited, -1);
    } 

}
