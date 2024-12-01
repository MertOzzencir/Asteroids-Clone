using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTSpawnManager : MonoBehaviour
{
    public GameObject[] spawnItem;
    public Collider SpawnArea;
    Bounds Boundrais;
    Vector3 minBounds;
    Vector3 maxBounds;
    int i = 1;
    void Start()
    {
        Die.OnScore += SpawnItem;
        Boundrais = SpawnArea.bounds;
        minBounds = new Vector3(Boundrais.min.x, 0.5f, Boundrais.min.z);
        maxBounds = new Vector3(Boundrais.max.x, 0.5f, Boundrais.max.z);

    }

   
    Vector3 GetRandomPointOnGround()
    {
        Vector3 spawnPoint = Vector3.zero;
        float xPosition = Random.Range(minBounds.x  , maxBounds.x );
        float zPosition = Random.Range(minBounds.z  , maxBounds.z );

        spawnPoint = new Vector3(xPosition, 35f, zPosition);
        if (Vector3.Distance(spawnPoint, UIManager.Instance.GetPlayerPosition()) < 10f) {
            return new Vector3(0, 35f, 7);
        }
        return spawnPoint;

    }

    void SpawnItem(int Score)
    {
        if(Score > 50 * i ) {
            i++;
            Instantiate(spawnItem[0], GetRandomPointOnGround(), Quaternion.identity);
        }
    }
}
