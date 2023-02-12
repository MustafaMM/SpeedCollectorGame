using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public MusicScript[] sounds;

    public static AudioManager instance; /*This is to make sure that we have only one Audio Manager. We create an instance, and if the editor recognizes a copy is made (because of
                                          * DontDestroyOnLoad) then we will destroy the gameObject this instance is on, so that we always have only 1 instance of the Audio Manager.
                                          * 
                                          * Obviously its static cause I want the song to keep playing in the next scene instead of restart.
                                          */


    void Start()
    {
        PlayMethod("Main Menu Soundtrack");
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return; //This is to make sure that if we destroy this game object, none of the code below might run
        }

        DontDestroyOnLoad(gameObject);

        foreach (MusicScript s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }

    public void PlayMethod(string theName)
    {
        // look through the sounds array, and find the sound that has the same name as the one in the method input.
        MusicScript s = Array.Find(sounds, sound => sound.name == theName);
        if(s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void QuitMethod(string theName)
    {
        // look through the sounds array, and find the sound that has the same name as the one in the method input.
        MusicScript s = Array.Find(sounds, sound => sound.name == theName);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
}
