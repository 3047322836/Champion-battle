using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckOfCard : MonoBehaviour
{
    public List<GameObject> OriginalCards = new List<GameObject>();
    public List<GameObject> cards = new List<GameObject>();
    public int count;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            int whichCard = i % OriginalCards.Count;
            GameObject card = Instantiate(OriginalCards[whichCard]); //to make an example of an original card
            card.transform.SetParent(canvas.transform);
            cards.Add(card);
            card.transform.position = Vector3.up * i * 301.0f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
