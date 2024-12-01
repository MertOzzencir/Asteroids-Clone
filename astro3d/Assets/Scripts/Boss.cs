using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    BossActionMode Mode;
    enum BossActionMode
    {
        Attack,
        Dodge,
        Sleep
        
    }

    private void Start()
    {
        Mode = BossActionMode.Attack;
    }
    private void Update()
    {
        switch(Mode) { 
            case BossActionMode.Attack:

                break;


            case BossActionMode.Dodge:
                break;


            case BossActionMode.Sleep:
                break;

            default:
                break;
        }
        
    }



}
