using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cards;

public class CardGenerator : MonoBehaviour
{
    public BasicCard basicCard;
    [Tooltip("how many to make?"), ContextMenuItem("create some cards", "generate")] // give count two properties
    public int count = 3;
    public Sprite[] images;
    public CardRead cards;



    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update() // automatically private
    {
        
    }

    public int suitConverter(string dictionary)
    {
        char x = dictionary[0];
        switch(x)
        {
            case 'C':
                return 0;
            case 'D':
                return 1;
            case 'H':
                return 2;
            case 'S':
                return 3;
        }
        return -1;
    }

    public readonly static Dictionary<string, int> suitConverterDictionary = new Dictionary<string, int>()
    {
        ["C"] = 0,
        ["D"] = 1,
        ["H"] = 2,
        ["S"] = 3
    };
    public void generate()
    {
        /*
        for(int i = 0; i < count; i++)
        {
            GameObject GO = Instantiate(basicCard.gameObject); // get object, not the script (script is a component)
            GO.transform.SetParent(this.transform); // top component, make new object a child
            BasicCard BC = GO.GetComponent<BasicCard>(); // bc references basic card rectangle
            BC.cardName = randomString(10);
            BC.description = randomSentence(10, 1, 10);
            int randomNum = Random.Range(0, images.Length);
            BC.image = images[randomNum];

            BC.ApplyUI();
        }
        */


        for (int i = 0; i < cards.cards.Length; i++)
        {
            GenerateCardsFor(cards.cards[i]);
        }
    }
    public void GenerateCardsFor(CardRead.CardInfo cardInfo)
    {
        for (int suitIndex = 0; suitIndex < cardInfo.list.Count; suitIndex++)
        {
            List<CardRead.CardInfo.card> cardnumbers = cardInfo.list[suitIndex].list;
            string suit = cardInfo.list[suitIndex].suit;
            for (int n = 0; n < cardnumbers.Count; ++n)
            {
                GameObject GO = Instantiate(basicCard.gameObject); // get object, not the script (script is a component)
                GO.transform.SetParent(this.transform); // top component, make new object a child
                BasicCard BC = GO.GetComponent<BasicCard>(); // bc references basic card rectangle
                BC.cardName = cardInfo.name;
                BC.description = cardInfo.description;
                BC.image = images[suitConverter(suit)];//same as the line below
                BC.image = images[suitConverterDictionary[suit]];
                BC.ApplyUI();
            }
        }
    }
}
