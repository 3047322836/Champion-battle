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

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update() // automatically private
    {
        
    }

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

    public void generate()
    {
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
    }
}
