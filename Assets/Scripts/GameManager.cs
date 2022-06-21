using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int playerhealth;
    private int health;

    private int score=0;


    public Text scoreText;

   public void addScore(int _score)
    {
        score += _score;
        scoreText.text = score.ToString();

    }

    public void damage(int _damage)
    {
        health -= _damage;
    }




    void Start()
    {
        addScore(0); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
