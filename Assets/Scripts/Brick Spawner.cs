using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject brick;
    [SerializeField] private BrickStorer storer;
    public List<GameObject> bricks = new List<GameObject>();

    void Start()
    {
        SpawnAllBricks();
    }

    public void SpawnAllBricks()
    {
        for (int i = 5; i > 0; i--)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject clone = Instantiate(brick, new Vector3(7.5f - 3 * j, i - 1, 0), Quaternion.identity);
                clone.GetComponent<Brick>().hp = i;
                bricks.Add(clone);
            }
        }
    }



    
    public void SpawnStoredBricks(List<BrickStorer.BrickSimple> bricksToLoad)
    {
        DestroyAllBricks();
        for (int i = 0; i < bricksToLoad.Count; i++)
        {
            GameObject clone = Instantiate(brick, new Vector3(bricksToLoad[i].x, bricksToLoad[i].y, 0), Quaternion.identity);
            clone.GetComponent<Brick>().hp = bricksToLoad[i].hp;
            bricks.Add(clone);

        }
    }

    void DestroyAllBricks()
    {
        if(bricks!=null)
        {
            foreach (GameObject go in bricks)
            {
                Destroy(go);
            }
            bricks.Clear();
        }
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
