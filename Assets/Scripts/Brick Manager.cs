using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class BrickManager : MonoBehaviour
{
    [SerializeField] private BrickSpawner spawner;
    [SerializeField] private BrickStorer storer;
    private List<BrickStorer.BrickSimple> bricks;
    [System.Serializable]
    private class AllBricks
    {
        public List<BrickStorer.BrickSimple> bricklist;
    }


    AllBricks allBricks= new AllBricks();

    private string saveJson;

    private string savePath = Application.dataPath + "/save.json";

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void GetBricks()
    {
        RequestStorage();
        bricks = storer.bricks;
        allBricks.bricklist = bricks;
    }

    
    void RequestStorage()
    {
        storer.StoreBricks(spawner.bricks);
    }

    void RequestSpawn()
    {
        spawner.SpawnStoredBricks(bricks);
    }


    void SaveBricksToJson()
    {
        GetBricks();
        saveJson = JsonUtility.ToJson(allBricks);
        File.WriteAllText(savePath, saveJson);
        Debug.Log(savePath);
    }

    

    void LoadBricksFromJson()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            JsonUtility.FromJsonOverwrite(json, allBricks);
            bricks = allBricks.bricklist;
            RequestSpawn();
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            SaveBricksToJson();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadBricksFromJson();
        }



    }
}
