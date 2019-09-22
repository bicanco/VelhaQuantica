using System.Collections.Generic;
public class Graph
{
    public bool[,] graph;
    private int size;

    public Graph(int size = 9){
        graph = new bool[size,size];
        this.size = size;
    }

    public void addEdge(int vertex1, int vertex2){
        graph[vertex1,vertex2] = true;
        graph[vertex2,vertex1] = true;
    }

    public void removeEdge(int vertex1, int vertex2){
        graph[vertex1,vertex2] = false;
        graph[vertex2,vertex1] = false;
    }

    public bool findCicles(int vertex){
        bool[] visited = new bool[size];
        return dfs(vertex, visited, -1);
    }

    private bool dfs(int v, bool[] visited, int parent){
        visited[v] = true;
        for(int i = 0; i < size; i++){
            if(graph[v,i]){
                if(visited[i] == false){
                    if(dfs(i,visited,v)){
                        return true;
                    }
                }else if(parent != i){
                    return true;
                }
            }
        }
        return false;
    }
}
