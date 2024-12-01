
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
   public TextMeshProUGUI ScoreText;
    MoveShip Player;

    private void Start()
    {
        Instance = this;
        Die.OnScore += ChangeUI;
        Player = FindObjectOfType<MoveShip>();
    }
    

    void ChangeUI(int score)
    {
        ScoreText.text = score.ToString();
    }
    public Vector3 GetPlayerPosition()
    {
        if( Player != null ) {
            return Player.transform.position;

        }
        else {
            return Vector3.zero;
        }
    }

}
