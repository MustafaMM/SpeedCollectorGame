using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class CoinScript : MonoBehaviour
{
    public TextMeshProUGUI theText;

    public static int collectablesCollected; //STATICCCCCCCCCC SO THAT IT DOES NOT GET DELETED WHEN EACH COIN GETS DELETED

    private bool hasEntered; //to check if coin collide with player
    private static bool hasEnteredLevel; // to check for collectables so that I can reset collectablesCollected every time I play again

    // Start is called before the first frame update
    void Start()
    {
        if(theText != null)
            theText = theText.GetComponent<TextMeshProUGUI>(); //Make sure you specify theText.GetComponent. If you only write GetComponent, it'll get component of the coin, which does not exist.
        
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 0)
        {
            collectablesCollected = 0; //Only set this to 0 when we at the first level, otherwise just continue from previous level.
        }

        if(theText != null)
            theText.text = collectablesCollected.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level 1" && !hasEnteredLevel)
        {
            hasEnteredLevel = true;
            collectablesCollected = 0;
            theText.text = collectablesCollected.ToString();
        }

        if(SceneManager.GetActiveScene().name != "Level 1")
        {
            hasEnteredLevel = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !hasEntered)
        {
            hasEntered = true;
            FindObjectOfType<AudioManager>().PlayMethod("Coin Sound");
            Destroy(gameObject);
            collectablesCollected = collectablesCollected + 1;
            theText.text = collectablesCollected.ToString();
        }
    }
}
