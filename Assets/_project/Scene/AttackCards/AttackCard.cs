using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cards;

public class AttackCard : MonoBehaviour
{
    public int attack;
    public void AttackSelected()
    {
        for (int i = 0; i < CardSelector.extraSelectedCard.Length; i++)
        {
            BasicCard c = CardSelector.extraSelectedCard[i];
            //if c is an champion card then create this new variable "ch"
            if (c is ChampionCard ch)
            {
                ch.hp -= attack;
                
            }
        }
        
    }
}
