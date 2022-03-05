using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardGameManager : MonoBehaviour
{
    [System.Serializable] public class Phase
    {
        public string name;
        public UnityEvent onEnter; // enter phase, something might happen

    }
    public List<Phase> phases = new List<Phase>()
    {
        new Phase {name = "starting"},
        new Phase {name = "divining"},
        new Phase {name = "drawing"},
        new Phase {name = "playing"},
        new Phase {name = "packing"},
        new Phase {name = "ending"},
    }; // keeps track of phases
    private int phaseIndex = 0;
    public Phase current;
    private static CardGameManager _instance; // variables that stores data, one true instance, no one can change it
    public static CardGameManager Instance => _instance; // adding an underscore: intentionally weird and difficult!!! dont try to think!!!
    private void Awake()
    {
        if (_instance != null)
        {
            throw new System.Exception("only one game manager allowed! >:(");
        }
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        current = phases[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void advancePhase()
    {
        phaseIndex++;
        if (phaseIndex >= phases.Count) // catches end of turn
        {
            phaseIndex = 0;
        }

        current = phases[phaseIndex];
        current.onEnter.Invoke();
    }
}
