using UnityEngine;

public class Field : MonoBehaviour
{
    public Cat cat;
    private GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("gameManager");
        // Instantiate(cat, this.transform.Find("Cats").transform, false);
    }
    
}
