using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckOfCard : MonoBehaviour
{
    public List<GameObject> OriginalCards = new List<GameObject>();
    public List<GameObject> cards = new List<GameObject>();
    public Sprite[] icons;
    public int count;
    public Canvas canvas;

    public Sprite image;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            int whichCard = i % OriginalCards.Count;
            GameObject card = Instantiate(OriginalCards[whichCard]); //to make an example of an original card
 
            Debug.Log(card.name);
            card.GetComponent<BasicCard>().icon = icons[0];
            card.GetComponent<BasicCard>().num = 42.ToString(); //"42";
            card.transform.SetParent(canvas.transform);
            cards.Add(card);
            //Debug.Log(card.GetComponent<BasicCard>().img_icon?.sprite?.name ?? "nothing");
            card.transform.position = Vector3.up * i * 305.0f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
