using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class EnemyRandomSpawnPointGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] EnemyPrefab;
    public Collider SpawnBounds;
    public int ObjectLuckValueToSpawn;

    Bounds Boundrais;
    Vector3 minBounds;
    Vector3 maxBounds;
    int levelDifficuilty = 0;

    public float BaseSpawnEnemyTimeValue;
     float SpawnEnemyTimeValue;
    float enemySpawnThreshold;


    public int[] difficulties;


    void Start()
    {
        Die.OnScore += OnScoreChangeToDifficuilty;
        SpawnEnemyTimeValue = BaseSpawnEnemyTimeValue;
        Boundrais = SpawnBounds.bounds;
        minBounds = new Vector3(Boundrais.min.x,0.5f, Boundrais.min.z);
        maxBounds = new Vector3(Boundrais.max.x, 0.5f, Boundrais.max.z);

    }

    void Update()
    {
        if(enemySpawnThreshold > SpawnEnemyTimeValue) {
            Instantiate(GetRandomObject(), GetRandomPointOnGround(),Quaternion.identity);
            enemySpawnThreshold = 0;

        }
        else {
            enemySpawnThreshold += Time.deltaTime;

        }


    }
    GameObject GetRandomObject()
    {
        int LuckThreshold = 1000;
        int ValueToDecisionToPickObject = Random.Range(0, LuckThreshold);
        if(ValueToDecisionToPickObject < ObjectLuckValueToSpawn) {
            return EnemyPrefab[0];
        }
        else {
            return EnemyPrefab[1];
        }

    }


    Vector3 GetRandomPointOnGround()
    {
        Vector3 spawnPoint = Vector3.zero;
        float xPosition = Random.Range(minBounds.x,maxBounds.x);
        float zPosition = Random.Range(minBounds.z,maxBounds.z);
      
        spawnPoint = new Vector3(xPosition,0.5f,zPosition);
        if (Vector3.Distance(spawnPoint, UIManager.Instance.GetPlayerPosition()) < 15f) {
            return new Vector3(-22, 0.5f, -37);
        }
        return spawnPoint;

    }

    void OnScoreChangeToDifficuilty(int Score)
    {
         if(Score == difficulties[levelDifficuilty] ) {
               levelDifficuilty++;

            if (levelDifficuilty >=difficulties.Length) {
                levelDifficuilty = difficulties.Length - 1;
                
            }
             SpawnEnemyTimeValue = SpawnEnemyTimeValue * .60f;
             Debug.Log("New Spawn Timer: " + SpawnEnemyTimeValue + "New Level Difficuilty: " + levelDifficuilty);
         }
        
    }
}
