using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/*
 * The script starts working when player reaches level 2. At level 1, the health is just a pic basically.
 */

public class TrapScript : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public static int currentHealth = 100;
    private bool hasEntered;
    private bool hasEnteredlvl2;

    public GameObject thePlayer;

    public Image healthUp100;
    public Image healthUp75;
    public Image healthUp50;
    public Image healthUp25;
    public Image healthDown100;
    public Image healthDown75;
    public Image healthDown50;
    public Image healthDown25;

    // Start is called before the first frame update
    void Start()
    {
        healthText = healthText.GetComponent<TextMeshProUGUI>();
        healthText.text = currentHealth.ToString();

        //I need to keep the image active in the editor/scene, but set it to false here so that I can change it in the Update() function................
        if (healthDown100 != null)
            healthDown100.enabled = false;

        if (healthDown75 != null)
            healthDown75.enabled = false;

        if (healthDown50 != null)
            healthDown50.enabled = false;

        if (healthDown25 != null)
            healthDown25.enabled = false;

        if (healthUp100 != null)
            healthUp100.enabled = true;
        
        if(healthUp75 != null)
            healthUp75.enabled = true;

        if (healthUp50 != null)
            healthUp50.enabled = true;

        if (healthUp25 != null)
            healthUp25.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 1" && !hasEnteredlvl2)
        {
            hasEnteredlvl2 = true;

            currentHealth = 100;
            healthText.text = currentHealth.ToString();
        }

        if(SceneManager.GetActiveScene().name != "Level 1")
        {
            hasEnteredlvl2 = false;
        }

        if(currentHealth < 0)
        {
            currentHealth = 0;
            healthText.text = currentHealth.ToString();
        }

        if(currentHealth == 100)
        {
            if (healthUp100 != null)
                healthUp100.enabled = true;
            if (healthUp75 != null)
                healthUp75.enabled = true;
            if (healthUp50 != null)
                healthUp50.enabled = true;
            if (healthUp25 != null)
                healthUp25.enabled = true;
            if (healthDown100 != null)
                healthDown100.enabled = false;
            if (healthDown75 != null)
                healthDown75.enabled = false;
            if (healthDown50 != null)
                healthDown50.enabled = false;
            if (healthDown25 != null)
                healthDown25.enabled = false;
        }

        if(currentHealth == 75)
        {
            if(healthUp100 != null)
                healthUp100.enabled = false;
            if(healthDown100 != null)
                healthDown100.enabled = true;
        }
        else if(currentHealth == 50)
        {
            if (healthUp100 != null)
                healthUp100.enabled = false;
            if (healthUp75 != null)
                healthUp75.enabled = false;
            if (healthDown100 != null)
                healthDown100.enabled = true;
            if (healthDown75 != null)
                healthDown75.enabled = true;
        }
        else if (currentHealth == 25)
        {
            if (healthUp100 != null)
                healthUp100.enabled = false;
            if (healthUp75 != null)
                healthUp75.enabled = false;
            if (healthUp50 != null)
                healthUp50.enabled = false;
            if (healthDown100 != null)
                healthDown100.enabled = true;
            if (healthDown75 != null)
                healthDown75.enabled = true;
            if (healthDown50 != null)
                healthDown50.enabled = true;
        }
        else if (currentHealth == 0)
        {
            if (healthUp100 != null)
                healthUp100.enabled = false;
            if (healthUp75 != null)
                healthUp75.enabled = false;
            if (healthUp50 != null)
                healthUp50.enabled = false;
            if (healthUp25 != null)
                healthUp25.enabled = false;
            if (healthDown100 != null)
                healthDown100.enabled = true;
            if (healthDown75 != null)
                healthDown75.enabled = true;
            if (healthDown50 != null)
                healthDown50.enabled = true;
            if (healthDown25 != null)
                healthDown25.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !hasEntered)
        {
            hasEntered = true;

            if(currentHealth > 0)
            {           
                if(gameObject.tag == "Trap")
                {
                    FindObjectOfType<AudioManager>().PlayMethod("Trap Sound");
                    currentHealth -= 50;
                    healthText.text = currentHealth.ToString();
                }
                else if(gameObject.tag == "SemiTrap")
                {
                    FindObjectOfType<AudioManager>().PlayMethod("Trap Sound");
                    currentHealth -= 25;
                    healthText.text = currentHealth.ToString();
                }
            }
            thePlayer.transform.Translate(-4, 1, 0);
        }
    }

    //We need the following block of code so that we reset the hasEntered variable, so that the next time we hit a trap we do lose health.
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && hasEntered)
        {
            hasEntered = false;
        }
    }
}
