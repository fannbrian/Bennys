using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerSpeechBubble : MonoBehaviour {
    public static string[] textarray= {"Welcome to Benny's", "WeCoMe To BeNnY’s!!", "Would you like desert ?",
                                "Take your time!", "Please take your time!", "Hi! Welcome! Welcome!",
                                "Benny’s is welcome to dessert-- you want dessert?", "Eat, eat, eeeeaaat at Benny’s!" };
   public Text servertext;
    int index = 0;
   void Start()
    {
        index = Random.Range(0, textarray.Length - 1);
        servertext.text = textarray[index];
    }
    public void Generatespeech()
    {
        index = Random.Range(0, textarray.Length - 1);
        servertext.text = textarray[index];
    }

}
