using System.Collections;
using System.Collections.Generic;

public class Graph
{
    private int N;
    private List<int>[] graph;

    public Graph(int size = 9){
        N = size;
        graph = new List<int>[size];
        for(int i = 0; i < size; i++){
            graph[i] = new List<int>();
        }
    }

    public void addEdge(int vertex1, int vertex2){
        graph[vertex1].Add(vertex2);
        graph[vertex2].Add(vertex1);
    }

    public void removeEdge(int vertex1, int vertex2){
        graph[vertex1].Remove(vertex2);
        graph[vertex2].Remove(vertex1);
    }

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

    public bool findCycle(int vertex){
        bool[] visited = new bool[N];
        for(int i = 0; i < N; i++){
            visited[i] = false;
        }
        // for(int i = 0; i < N; i++){
        //     if(!visited[i])
        //         if(dfs(i, visited, -1))
        //             return true;
        // }
        // return false;
        return dfs(vertex, visited, -1);
    } 

    public List<int>[] print() {
        return graph;
    }
}
