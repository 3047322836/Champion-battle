using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using cards;
using System;

public class CardSelector : MonoBehaviour
{
    public BasicCard mainSelected;
    public BasicCard[] additionalSelected;
    private static CardSelector _instance;
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;

    }
    public static void setExtraSelection(int n)
    {
        _instance.additionalSelected = new BasicCard[n];
    }

    void SelectSingleCard(BasicCard card) {
        mainSelected?.deSelected.Invoke();
        mainSelected = card;
        Debug.Log("New Selections " + mainSelected);
        mainSelected?.onSelected.Invoke();
    }
    void MultiCardSelectionLogic(BasicCard card) {
        int nextIndex = Array.IndexOf(additionalSelected, card);
        if (nextIndex >= 0) {
            additionalSelected[nextIndex] = null;
        } else {
            nextIndex = Array.IndexOf(additionalSelected, null);
            if (nextIndex >= 0) {
                additionalSelected[nextIndex] = card;
            }
        }
    }
    bool IsLeftMouseButtonClicked() { return Input.GetMouseButtonDown(0); }
    void DoSelectionLogic() {
        GameObject go = EventSystem.current.currentSelectedGameObject;
        if (go == null) { return; }
        BasicCard card = go.GetComponent<BasicCard>();
        if (card != null) {
            if (additionalSelected.Length == 0) {
                SelectSingleCard(card);
            } else {
                MultiCardSelectionLogic(card);
            }
        }
    }
    void Update() {
		if (IsLeftMouseButtonClicked()) {
            DoSelectionLogic();
		}
    }
}
