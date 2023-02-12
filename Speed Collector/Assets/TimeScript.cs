using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeScript : MonoBehaviour
{
    [HideInInspector]
    public static float theTime = 0.0f;

    [HideInInspector]
    public static int theTimeInSeconds = 0;

    // Update is called once per frame
    void Update()
    {
        theTime += Time.deltaTime;
        theTimeInSeconds = (int)(theTime % 60);

        if(gameObject.GetComponent<TextMeshProUGUI>() != null)
            gameObject.GetComponent<TextMeshProUGUI>().text = theTimeInSeconds.ToString() + " sec";
    }
}
