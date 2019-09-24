
public class Graph
{
    public bool[,] graph;

    public Graph(int size = 9){
        graph = new bool[size,size];
    }

    public void addEdge(int vertex1, int vertex2){
        graph[vertex1,vertex2] = true;
        graph[vertex2,vertex1] = true;
    }

    public void removeEdge(int vertex1, int vertex2){
        graph[vertex1,vertex2] = false;
        graph[vertex2,vertex1] = false;
    }

    private bool dfs(int v, bool[] visited, int parent){
        visited[v] = true;

        for(int i = 0; i < graph.GetLength(0); i++){
            if(graph[v, i]){
                if(!visited[i]){
                    if(dfs(i, visited, v)){
                        return true;
                    }
                }else if( parent != i){
                    return true;
                }
            }
        }

        return false;
    }

    public bool findCycles(int vertex){
        bool[] visited = new bool[graph.GetLength(0)];
        return dfs(vertex, visited, -1);
    }      
}
