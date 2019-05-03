using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    const int BASE_SCORE = 10000;
    const int CHERRY_MULTIPLIER = 200;
    const int DEATH_MULTIPLIER = 200;

    public Text winText;
    private int playerScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        int cherryCount = PlayerPrefs.GetInt("cherries");
        int deathCount = PlayerPrefs.GetInt("deaths");
        int finalScore = BASE_SCORE + cherryCount * CHERRY_MULTIPLIER - deathCount * DEATH_MULTIPLIER;
       
        winText.text = "Cherries: " + cherryCount.ToString() +
                        "\nDeaths: " + deathCount.ToString() +
                        "\nFinal Score: " + string.Format("{0:n0}", finalScore.ToString());
    }
}
