using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckOfCard : MonoBehaviour
{
    public List<GameObject> OriginalCards = new List<GameObject>();
    public List<GameObject> cards = new List<GameObject>();
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            int whichCard = i % OriginalCards.Count;
            GameObject card = Instantiate(OriginalCards[i]); //to make an example of an original card
            cards.Add(card);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
