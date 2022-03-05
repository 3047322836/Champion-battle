using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace cards
{

    public class BasicCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [ContextMenuItem("apply GUI data", nameof(ApplyUI))]
        public string cardName;
        public Sprite image;
        public Sprite icon;
        public string num;
        //[TextArea(1, 5), Tooltip("describs the card")]
        public string description;
        public UnityEvent onPlay;
        public UnityEvent onExit;
        public TMP_Text txt_title, txt_description;
        public RectTransform descriptionWindow;
        public Image img_image;
        public Image img_icon;
        public TMP_Text cardNum;
        public UnityEvent onSelected;
        public UnityEvent deSelected;
        public bool selected;
        public bool isGrowing;
        public float speed = 0.1f;
        public float selectedSize = 1.01f;
        public float animationTimer;
        public float _animationDuration = 3;
        private Color startingColor;
        public Color selectedColor = Color.white;
        public enum SelectedStyle
        {
            none, growShrink, flashColor, growShrinkFlashColor
        }
        public SelectedStyle selectedStyle;

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
            startingColor = GetComponent<Image>().color;
            ApplyUI();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
           if (selected)
            {
                SelectedAnimationLogic();
            }
           if (descriptionWindow.gameObject.activeSelf)
            {
                descriptionWindow.position = Input.mousePosition;
            }
    
           
        }
        
        private void SelectedAnimationLogic()
        {

            float progress = animationTimer / _animationDuration;
            if (progress > 1)
            {
                progress = 1;
            }
            if (progress < 0)
            {
                progress = 0;
            }
            if (!isGrowing)
            {
                animationTimer -= Time.deltaTime;
                //transform.localScale -= Vector3.one * Time.deltaTime * speed;
                //if (transform.localScale.x <= 1)
                if (progress == 0)
                {
                    isGrowing = true;
                }
            }
            else
            {
                animationTimer += Time.deltaTime;
                //transform.localScale += Vector3.one * Time.deltaTime * speed;
                if (progress == 1)
                {
                    isGrowing = false;
                }
            }
            //interpolation calculation
            //value = min + delta * progress
            Vector3 min = Vector3.one;
            Vector3 max = Vector3.one * selectedSize;
            Vector3 delta = max - min;
            //transform.localScale = min + delta * progress;

            //if (selectedStyle == SelectedStyle.growShrink)
            //{
            //    transform.localScale = Vector3.Lerp(min, max, progress);
            //}
            //if (selectedStyle == SelectedStyle.flashColor)
            //{
            //    GetComponent<Image>().color = Color.Lerp(startingColor, selectedColor, progress);
            //}
            //if (selectedStyle == SelectedStyle.growShrinkFlashColor)
            //{
            //    transform.localScale = Vector3.Lerp(min, max, progress);
            //    GetComponent<Image>().color = Color.Lerp(startingColor, selectedColor, progress);
            //}

            //switch statement is just doing the same thing as the if statement above
            //switch is a structured of goto
            //goto is their boss
            //switch is a good devil
            //break and continue are lawful devil
            // if, while, and for are structured programing, so they are angels, they betrayed their boss
            switch (selectedStyle)
            {
                case SelectedStyle.growShrink:
                    transform.localScale = Vector3.Lerp(min, max, progress);
                    break;
                case SelectedStyle.flashColor:
                    GetComponent<Image>().color = Color.Lerp(startingColor, selectedColor, progress);
                    break;
                case SelectedStyle.growShrinkFlashColor:
                    transform.localScale = Vector3.Lerp(min, max, progress);
                    GetComponent<Image>().color = Color.Lerp(startingColor, selectedColor, progress);
                    break;
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
            //transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            selected = true;
        }
        public void Unselect()
        {
            GetComponent<Image>().color = startingColor;
            transform.localScale = Vector3.one;
            selected = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            descriptionWindow.gameObject.SetActive(true);
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            descriptionWindow.gameObject.SetActive(false);
        }
    }
}
