using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRead : MonoBehaviour
{
    [System.Serializable] public class CardInfo
    {
        public string name;
        public string type;
        public string description;
        public int HP;
        public int cardCount;
        public enum card { A, _2, _3, _4, _5, _6, _7, _8, _9, _10, J, Q, K}
        [System.Serializable]public struct Listing
        {
            public string suit;
            public List<card> list;
        }
        public List<Listing> list = new List<Listing>();

        public Dictionary<string, List<card>> dictionary;
        //public string dictionary;
        public CardInfo(string name, string type, string description, string HP, string cardCount, string suits, string dictionary) {
            this.name = name;
            this.type = type;
            this.description = description;
            this.cardCount = Int32.Parse(cardCount);
            //this.dictionary = dictionary;
            
            switch (HP)
            {
                case "n/a":
                case "":
                    this.HP = 0;
                    break;
                default: this.HP = int.Parse(HP);
                    break;
            }
            for(int i = 0; i < dictionary.Length; i++)
            {
                char c = dictionary[i];
                switch(c)
                {
                    case ':':
                    case '(':
                    case ')':
                    case ' ':
                        continue;
                    case 'H':
                    case 'D':
                    case 'S':
                    case 'C':
                        list.Add(new Listing { suit = c.ToString(), list = new List<card>()});
                        break;
                    case 'A':
                        list[list.Count - 1].list.Add(card.A);
                        break;
                    case '2':
                        list[list.Count - 1].list.Add(card._2);
                        break;
                    case '3':
                        list[list.Count - 1].list.Add(card._3);
                        break;
                    case '4':
                        list[list.Count - 1].list.Add(card._4);
                        break;
                    case '5':
                        list[list.Count - 1].list.Add(card._5);
                        break;
                    case '6':
                        list[list.Count - 1].list.Add(card._6);
                        break;
                    case '7':
                        list[list.Count - 1].list.Add(card._7);
                        break;
                    case '8':
                        list[list.Count - 1].list.Add(card._8);
                        break;
                    case '9':
                        list[list.Count - 1].list.Add(card._9);
                        break;
                    case '1':
                        list[list.Count - 1].list.Add(card._10);
                        break;
                    case 'J':
                        list[list.Count - 1].list.Add(card.J);
                        break;
                    case 'Q':
                        list[list.Count - 1].list.Add(card.Q);
                        break;
                    case 'K':
                        list[list.Count - 1].list.Add(card.K);
                        break;
                }
            }
            for (int i = 0; i<list.Count; i++)
            {
                string suit = list[i].suit;
                this.dictionary[suit] = list[i].list;
            }
            Debug.Log(this.dictionary["H"].Count);
        }
    }
    public CardInfo[] cards = new CardInfo[]
    {
        new CardInfo("attack","basic","use [attack] to another champion within your attack range in your playing section to deal 1 point of damage to him or her. You can only play 1 [attack] in your playing section.","-1","30","S (7) H (3) C(14) D (6)","S: 7 8 8 9 9 10 10 H: 10 10 J C: 2 3 4 5 6 7 8 8 9 9 10 10 J J D: 6 7 8 9 10 K"),
        new CardInfo("defense","basic","use [defense] when someone plays [attack] to you, [defense] can offset the effect of [attack].","n/a","15","H (3)D (12)","H: 2 2 K D: 2 2 3 4 5 6 7 8 9 10 J J"),
        new CardInfo("potion of blood","basic","use [potion of blood] to yourself in your playing section to restore 1 HP to yourself. Also only when one champion’s HP becomes equal or less than 0, play [potion of blood] to restore 1 HP to that champion.","1","8","H (7)D (1)","H: 3 4 6 7 8 9 QD: Q"),
        new CardInfo("potion of rage","basic","use [potion of rage] to yourself in your playing section to gain 1 point of damage to the next [attack] you play. You can only play 1 [potion of rage] in your playing section. Also when your HP is equal or less than 0, you can play [potion of rage] to restore 1 HP for you.","","3","S (1)C(1)D (1)","S: 3 C: 3 D: 9"),
        new CardInfo("guard","skill","use [guard] to offset the effect of a skill card, or play [guard] to offset the effect of another [guard].","","3","S (1)H (2)","S: K H: K A"),
        new CardInfo("destroy","skill","use [destroy] to another champion in your playing section to discard a card in that champion’s area.","","6","S (3)H (1)C(2)","S: 3 4 Q H: Q C: 3 4"),
        new CardInfo("steal","skill","use [steal] to another champion who’s distance with you equals or less than 1 in your playing section to get a card in that champion’s area.","","5","S (3)D (2)","S: 3 4 J D: 3 4"),
        new CardInfo("duel","skill","use [duel] to another champion in your playing section to start a duel with that champion, you and that champion play [attack] alternately. That champion starts first. The champion who does not play [attack] takes 1 point of damage from another champion in duel.","","3","S (1)C(1)D (1)","S: A C: A D: A"),
        new CardInfo("zombie siege","skill","use [zombie siege] in your playing section, every champion except you have to play a [attack] or take 1 point of damage from you.","","3","S (2)C(1)","S: 7  KC: 7"),
        new CardInfo("arrows rain","skill","use [arrows rain] in your playing section, every champion except you have to play a [defense] or take 1 point of damage from you.","","1","H (1)","H: A"),
        new CardInfo("replenish","skill","use [replenish] to yourself in your playing section, draw 2 cards.","","4","H (4)","H: 7 8 9 J"),
        new CardInfo("spring is coming","skill","use [Spring is coming] in your playing section, every champion restores 1 HP.","","1","H (1)","H: A"),
        new CardInfo("money rain","skill","use [money rain] to everyone in your playing section, you show x cards in the deck (x is the number of alive champions), start with you, every champion picks up one card from these cards you showed up in order.","","2","H (2)","H: 3 4"),
        new CardInfo("employ","skill","use [employ] to a champion who has a weapon card in his or her equipment area in your playing section, that champion has to choose one: 1. Play an [attack] to another champion in his/her range you select; 2. Give his/her weapon to you.","","2","C(2)","C: Q K"),
        new CardInfo("freeze","delay skill","place [freeze] in a champion’s divining area in your playing section if that champion doesn’t have a [freeze] in his or her divining area, when that champion’s divining section starts, he/she has to make a divination. If the result is not H️, discards this [freeze] and skip the playing section.","","3","S (1) H (1) C(1)","S: 6H: 6C: 6"),
        new CardInfo("starve","delay skill","place [starve] in a champion’s divining area in your playing section if that champion doesn’t have a [starve] in his or her divining area, when that champion’s divining section starts, he/she has to make a divination. If the result is not C️, discards this [starve] and skip the drawing section","","3","S (2) C(1)","S: 10 2 C: 10"),
        new CardInfo("lighting","delay skill","place [lighting] in your divining section in your playing section if you don’t have a [lighting] in your divining section, when a champion’s turn start a divining section, if [lighting] is in his/her divining area, he/she has make a divination, if the result is not S️2~9, he/she place [lighting] in his/her next player’s divination area; Otherwise, he/she takes 3 points of damages.","","2","S (1)H (1)","S: A H: Q"),
        new CardInfo("hunting gun","equipage","weapon, attack range: 3, ability: After using [attack] to damage one champion, you can discard one card from his/her equipment area.","","1","H (1)","H: 5"),
        new CardInfo("captain's shield","equipage","armor, ability: locked, when you take more than 1 point of damage, you ignore the overflow damage.","","1","C(1)","C: 2"),
        new CardInfo("firing scepter","equipage","weapon, attack range: 2, ability: You can use two cards in your hand as an [attack] to play or use.","","1","S (1)","S: Q"),
        new CardInfo("ancient bow","equipage","weapon, attack range: 5, ability: locked, when you are using [attack] to a champion, you ignore that champion’s armor.","","1","S (1)","S: 6"),
        new CardInfo("golden axe","equipage","weapon, attack range: 3, ability: when your [attack] is blocked by [defense], you can discard two cards from your hand to make this [attack] still do damage.","","1","D (1)","D: 5"),
        new CardInfo("bagua","equipage","armor, ability: when you need to use or play a [defense], you can make a divination. If the result is H️ or D️, you can use or play a [defense] without consuming any card in your hand.","","2","S (1)C(1)","S: 2C: 2"),
        new CardInfo("hex-bow","equipage","weapon, attack range: 1, ability: locked, you can play an infinite number of [attack] in your playing section.","","2","C(1)D (1)","C: A D: A"),
        new CardInfo("poseiden trident","equipage","weapon, attack range: 4, ability: when you play [attack] to another champion, and the [attack] you played is the last card in your hand, you can gain two extra targets for your [attack].","","1","D (1)","D: Q"),
        new CardInfo("wuju blade","equipage","weapon, attack range: 2, ability: locked, when you play [attack] to another champion, if he or she doesn’t have any card in his or her hand, the [attack] you play will deal 1 point more damage to that champion.","","1","S (1)","S: A"),
};


    // Start is called before the first frame update
    void Start()
    {
        
    }
}
