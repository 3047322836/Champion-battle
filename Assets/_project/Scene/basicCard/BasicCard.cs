using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace cards
{

    public class BasicCard : MonoBehaviour
    {
        [ContextMenuItem("apply GUI data", nameof(ApplyUI))]
        public string cardName;
        public Sprite image;
        public Sprite icon;
        public string num;
        [TextArea(1, 5), Tooltip("describs the card")]
        public string description;
        public UnityEvent onPlay;
        public UnityEvent onExit;
        public TMP_Text txt_title, txt_description;
        public Image img_image;
        public Image img_icon;
        public TMP_Text cardNum;
        public UnityEvent onSelected;
        public UnityEvent deSelected;
        public bool selected;
        public bool isGrowing;
        public float speed = 0.1f;
        public float selectedSize = 1.01f;

        public virtual void ApplyUI()
        {
            txt_title.text = cardName;
            txt_description.text = description;
            img_image.sprite = image;
            img_icon.sprite = icon;
            cardNum.text = num;

        }
        // Start is called before the first frame update
        protected virtual void Start()
        {
            ApplyUI();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
           if (selected)
            {
                if (!isGrowing)
                {
                    transform.localScale -= Vector3.one * Time.deltaTime * speed;
                    if (transform.localScale.x <= 1)
                    {
                        isGrowing = true;
                    }
                }
                else
                {
                    transform.localScale += Vector3.one * Time.deltaTime * speed;
                    if (transform.localScale.x >= selectedSize)
                    {
                        isGrowing = false;
                    }
                }
     
            }
           
        }

        public void ChangeHP()
        {
            Debug.Log("change hp");
        }

        private void OnMouseDown()
        {
            onPlay.Invoke();
        }

        public void requestSelection(int n)
        {
            CardSelector.setExtraSelection(n);
        }
        public void Select()
        {
            transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            selected = true;
        }
        public void Unselect()
        {
            transform.localScale = Vector3.one;
            selected = false;
        }
    }
} 