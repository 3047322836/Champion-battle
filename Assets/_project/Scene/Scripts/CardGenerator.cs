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
    /*
    public static string randomString(int length)
    {
        string str = "";
        for (int i = 0; i < length; i++)
        {
            str += (char) ('a' + Random.Range(0, 26));
        }
        return str;
    }
    
    public static string randomSentence(int wordCount, int minWordLength, int maxWordLength)
    {
        string str = "";
        for(int i = 0; i < wordCount; i++)
        {
            if (i > 0)
            {
                str += " ";
            }
            str += randomString(Random.Range(minWordLength, maxWordLength));

        }

        return str;
    }
    */



    public void suitConverter(string dictionary)
    {
        List<int> suitt = new List<int>();
        for(int j = 0; j < dictionary.Length; j++)
        {
            char x = dictionary[j];
            switch(x)
            {
                case ':':
                case ' ':
                case 'A':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '1':
                case 'J':
                case 'Q':
                case 'K':
                    continue;

                case 'C':
                    suitt.Add(0);
                    break;
                case 'D':
                    suitt.Add(1);
                    break;
                case 'H':
                    suitt.Add(2);
                    break;
                case 'S':
                    suitt.Add(3);
                    break;
            }
        }
    }
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

        GameObject GO = Instantiate(basicCard.gameObject); // get object, not the script (script is a component)
        GO.transform.SetParent(this.transform); // top component, make new object a child
        BasicCard BC = GO.GetComponent<BasicCard>(); // bc references basic card rectangle
        for (int i = 0; i < cards.cards.Length; i++)
        {
            BC.cardName = cards.cards[i].name;
            BC.description = cards.cards[i].description;
            for (int k = 0; k < cards.cards[i].cardCount; k++)
            {
                BC.image = images[i];
                BC.ApplyUI();
            }
        }

    }
}
