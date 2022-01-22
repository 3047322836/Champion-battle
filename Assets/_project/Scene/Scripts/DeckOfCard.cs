using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace cards
{

    public class DeckOfCard : MonoBehaviour
    {
        public List<GameObject> OriginalCards = new List<GameObject>();
        public List<GameObject> cards = new List<GameObject>();

        //public List<Canvas> Images = new List<Canvas>();
        public string[] numB = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        public Sprite[] icons;
        public int count;
        public Canvas canvas;

        public Sprite image;
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < count; i++)
            {
                int NumB = Random.Range(0, 13);
                int IconB = Random.Range(0, 3);
                Debug.Log(NumB);
                int whichCard = i % OriginalCards.Count;
                GameObject card = Instantiate(OriginalCards[whichCard]); //to make an example of an original card


                Debug.Log(card.name);
                card.GetComponent<BasicCard>().icon = icons[IconB];
                card.GetComponent<BasicCard>().num = numB[NumB];
                //Debug.Log(card.GetComponent<BasicCard>().img_icon?.sprite?.name ?? "nothing");

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
}