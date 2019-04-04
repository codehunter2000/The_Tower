using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{

    public Text winText;
    private int playerScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        playerScore = PlayerPrefs.GetInt("score");
        winText.text = "You Win! \nScore: " + playerScore;
    }
}
