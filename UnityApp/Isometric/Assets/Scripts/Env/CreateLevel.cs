using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateLevel : MonoBehaviour {

    public List<Block> Blocks = new List<Block>();
    public int MaxBlocks = 10;
    public List<Enemy> Enemies = new List<Enemy>();
    public int MaxEnemies = 10;
    public List<Enemy> SpawnedEnemies = new List<Enemy>();
    public int Seed = 1;

    public float SpawnTime = 2f;
    float timer;

	// Use this for initialization
	void Start () {
        if(MaxBlocks > 0)
        { 
            Random.seed = Seed;
            var numBlocks = Random.Range(0, MaxBlocks);
            for (int i = 0; i < numBlocks; i++)
            {
                Block b = Instantiate(Blocks[Random.Range(0, Blocks.Count)]) as Block;
                b.transform.position += new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            }
        }

        OnScreenGUI.ToDo.Add(sendOnGUI);
	}

    void Update()
    {
        if(timer < SpawnTime)
        {
            timer += Time.deltaTime;
            if(timer >= SpawnTime)
            {
                SpawnEnemies();
            }
        }
    }

    public void SpawnEnemies()
    {
        var numEnemies = Random.Range(0, MaxEnemies);
        for (int i = 0; i < numEnemies; i++)
        {
            Enemy b = Instantiate(Enemies[Random.Range(1, Enemies.Count)]) as Enemy;
            b.transform.position += new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            SpawnedEnemies.Add(b);
        }
    }

    public void sendOnGUI()
    {
        GUILayout.Label("ENEMIES : " + SpawnedEnemies.Count);
    }

}
