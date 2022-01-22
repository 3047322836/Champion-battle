using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace cards
{
    public class ChampionCard : BasicCard
    {
        public int hp = 3;
        public int maxHP = 5;

        public override void ApplyUI()
        {
            txt_title.text = cardName;
            txt_description.text = description;
            img_image.sprite = image;
            //img_icon.sprite = icon;
            cardNum.text = hp + "/" + maxHP;

        }

        // Start is called before the first frame update
        //void is saying that the method is missing a return value?
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}