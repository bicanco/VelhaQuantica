
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
}
