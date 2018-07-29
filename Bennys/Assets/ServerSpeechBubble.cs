using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerSpeechBubble : MonoBehaviour {
    public static string[] textarray= {"Welcome to Benny's", "WeCoMe To BeNnY’s!!", "Would you like desert ?",
                                "Take your time!", "Please take your time!", "Hi! Welcome! Welcome!",
                                "Benny’s is welcome to dessert-- you want dessert?", "Eat, eat, eeeeaaat at Benny’s!" };

    public static string[] textarraycook = {"Let’s get cookin’", "LET'S TURN UP THE HEAT!", "Order up!",
                                "Order up, right now please.", "Here, let me show you the Benny’s welcome.", "Benny is the true cook, I’m only the knife in its hands.",
                                "Benny welcomes you out there. Please take a seat and order up.", "Ready to eat already? Little impatient, but that’s okay. We will feed ya…","If you want the cook’s attention, show me your pockets." };
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
    public void GeneratecookSpeech()
    {
        index = Random.Range(0, textarray.Length - 1);
        servertext.text = textarraycook[index];
    }

}
