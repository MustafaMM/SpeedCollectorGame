using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    float speed = 40f;
    float movement = 0f;
    float finalMvmnt = 1f; //This value should be either 0 or 1, if the player at the end, set it to 0 so the player's speed gradually decreases till he stops.

    static bool jumper = false;
    bool theFinalJumper = true;

    Collider2D collision;
    
    Touch touch;

    bool hasRemovedFinger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Execlusive OR: if only one of them is true, and not both. 
        if (Input.GetButton("Jump"))
        {
            movement =  Input.GetAxis("Jump") * speed;
        }
        else if(Input.touchCount > 0)
        {
            hasRemovedFinger = false;
            touch = Input.GetTouch(0);
            movement = touch.pressure * speed;
        }
        else
        {
            movement = 0f;
        }

        if (Input.GetButtonUp("Jump") ^ (touch.phase == TouchPhase.Ended && hasRemovedFinger == false && touch.position.y < (float)Screen.height/2f))
        {
            hasRemovedFinger = true;
            jumper = true;
            if (collision != null)
            {
                OnTriggerEnter2D(collision);
            }
            jumper = theFinalJumper;
        }

        if (finalMvmnt == 0)
        {
            if(speed > 0)
            {
                speed = speed - 0.1f;
            }
            else
            {
                speed = 0f;
            }
        }
    }
    
    void FixedUpdate()
    {
        controller.Move(movement * Time.fixedDeltaTime, false, jumper);
        jumper = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Environment"))
        {
            theFinalJumper = false;
            finalMvmnt = 0f;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            if(SceneManager.GetActiveScene().name == "Level 3")
            {
                FindObjectOfType<AudioManager>().QuitMethod("PlayerTheme");
                FindObjectOfType<AudioManager>().PlayMethod("Main Menu Soundtrack");
            }
        }
    }
}
