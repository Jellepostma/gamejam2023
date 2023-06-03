using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorable : MonoBehaviour
{

    public int points;

    public void Score(int player)
    {
        ScoreManager.instance.AddScore(player, points);
    }
    
}
