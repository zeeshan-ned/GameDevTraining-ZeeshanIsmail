using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundtile;
    Vector3 nextSpawnpoint;
    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundtile, nextSpawnpoint, Quaternion.identity);
        nextSpawnpoint = temp.transform.GetChild(1).transform.position;    
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();
        }    
    }    
}
