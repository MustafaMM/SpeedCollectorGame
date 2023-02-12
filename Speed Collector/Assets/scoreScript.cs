using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int theNumCollected = CoinScript.collectablesCollected;
        int theCurrentHealth = TrapScript.currentHealth;
        int theCurrentTime = TimeScript.theTimeInSeconds;
        theCurrentTime = 600 - theCurrentTime; //max of 10 min, randomly assigned it...

        int coinsValue = theNumCollected * 100;
        int healthValue = theCurrentHealth * 20;
        int timeValue = theCurrentTime * 5;

        int finalScore = coinsValue + healthValue + timeValue;

        gameObject.GetComponent<Text>().text = "Score : " + finalScore;
    }

}
