using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickStorer : MonoBehaviour
{
    [SerializeField] private BrickSpawner spawner;
    [SerializeField] private Brick brickTemplate;
    [System.Serializable]
    public class BrickSimple
    {
       public float x = 0;
       public float y = 0;
       public int hp = 0;
    }
    public List<BrickSimple> bricks = new List<BrickSimple>();

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StoreBricks(List<GameObject> bricksInGame)
    {
        if (bricks != null)
        {
            bricks.Clear();
        }
        foreach (GameObject go in bricksInGame)
        {
            if(go != null)
            {
                BrickSimple brick = new BrickSimple();
                brick.x = go.transform.position.x;
                brick.y = go.transform.position.y;
                brick.hp = go.GetComponent<Brick>().hp;
                bricks.Add(brick);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
