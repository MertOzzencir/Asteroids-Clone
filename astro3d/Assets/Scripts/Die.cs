using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Die : MonoBehaviour
{
    public static event Action<int> OnScore;
    public ParticleSystem RockParticleSystem;

    private ParticleSystem instanceofRock;
    public int Health;
    public int ScoreValue;
    MoveShip Player;
    Vector3 Direction;
    public float speed;
    Rigidbody rb;
    static int Score;
    
    private void Start()
    {
        speed = UnityEngine.Random.Range(4f,8f);
        Player = FindAnyObjectByType<MoveShip>();
        rb = GetComponent<Rigidbody>();
    }

   
    private void Update()
    {
        if(Player != null) {
            Direction = (Player.transform.position - transform.position).normalized;

        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(Direction.x,0,Direction.z) * speed;
    }
    private void OnDestroy()
    {
        DestroySelf();
    }

    public void DestroySelf()
    {
        instanceofRock = Instantiate(RockParticleSystem, transform.position,Quaternion.identity);
        Score = Score + ScoreValue;
        OnScore?.Invoke(Score);
        Destroy(gameObject);
    }
  




}
