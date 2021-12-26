using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionCard : MonoBehaviour
{
    public string cardName;
    public int hp;
    public int maxHP;
    [TextArea(1,5), Tooltip("describs the card")]
    public string description;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
