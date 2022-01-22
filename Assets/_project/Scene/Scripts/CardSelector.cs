using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using cards;
public class CardSelector : MonoBehaviour
{
    public BasicCard mainSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BasicCard card = null;
        GameObject go = EventSystem.current.currentSelectedGameObject;
        if (go)
        {
            card = go.GetComponent<BasicCard>();
            if (card != null && card != mainSelected)
            {
                if (mainSelected != null)
                {
                    mainSelected.deSelected.Invoke();
                }
                mainSelected = card;
                Debug.Log("New Selections " + mainSelected);
                if (mainSelected != null)
                {
                    mainSelected.onSelected.Invoke();
                }
            }
        }
    }
}
