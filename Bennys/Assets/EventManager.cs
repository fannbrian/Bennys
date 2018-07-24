using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour {

    EventSystem m_EventSystem;

    GameObject ArcadeUI;

    GameObject TableUI;

    [SerializeField]
    bool ArcadeOn;

    [SerializeField]
    bool TableOn;

    void Start()
    {
        ArcadeUI = GameObject.FindGameObjectWithTag("ArcadeUI");

        TableUI = GameObject.FindGameObjectWithTag("TableUI");
    }

    void OnEnable()
    {
        //Fetch the current EventSystem. Make sure your Scene has one.
        m_EventSystem = EventSystem.current;
    }

    // Update is called once per frame
    void Update ()
    {
        if (ArcadeUI.activeInHierarchy == true)
        {
            m_EventSystem.SetSelectedGameObject(ArcadeUI);
        }

        else if (TableUI.activeInHierarchy == true)
        {
            m_EventSystem.SetSelectedGameObject(TableUI);
        }
	}
}