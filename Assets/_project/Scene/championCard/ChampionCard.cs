using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace cards
{
    public class ChampionCard : BasicCard
    {
        [SerializeField] private int _hp = 5;
        public int maxHP = 5;

        public GameObject endingSectionUI;

        public int hp
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
                cardNum.text = _hp + "/" + maxHP;
                //can set limitation of the hp here
                //wrap logic here
            }
        }
        

        public override void ApplyUI()
        {
            txt_title.text = cardName;
            txt_description.text = description;
            img_image.sprite = image;
            //img_icon.sprite = icon;
            cardNum.text = _hp + "/" + maxHP;

        }

        // Start is called before the first frame update
        //void is saying that the method is missing a return value?
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
            endingSectionUI.SetActive(CardGameManager.Instance.current.name == "ending");
            
        }
    }
}