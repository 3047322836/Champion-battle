using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using cards;
using System;

public class CardSelector : MonoBehaviour
{
    public BasicCard mainSelected;
    public BasicCard[] extraThingsToSelect;
    private static CardSelector _instance;
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;

    }
    public static void setExtraSelection(int n)
    {
        _instance.extraThingsToSelect = new BasicCard[n];
    }

    void SelectSingleCard(BasicCard card) {
        mainSelected?.deSelected.Invoke();
        mainSelected = card;
        Debug.Log("New Selections " + mainSelected);
        mainSelected?.onSelected.Invoke();
    }

    void MultiCardSelectionLogic(BasicCard card) {
        int whereThisCardIsInTheSelection = Array.IndexOf(extraThingsToSelect, card);
        bool thisCardIsAlreadySelected = whereThisCardIsInTheSelection >= 0;
        if (thisCardIsAlreadySelected) {
            extraThingsToSelect[whereThisCardIsInTheSelection] = null; // unselects the card
        } else {
            if (card == mainSelected) {
                SelectSingleCard(null);
                return;
			}
            int emptySlotInSelection = Array.IndexOf(extraThingsToSelect, null);
            if (emptySlotInSelection >= 0) {
                extraThingsToSelect[emptySlotInSelection] = card;
            }
        }
    }

    bool IsLeftMouseButtonClicked() { return Input.GetMouseButtonDown(0); }

    void DoSelectionLogic() {
        GameObject go = EventSystem.current.currentSelectedGameObject;
        if (go == null) { return; }
        BasicCard card = go.GetComponent<BasicCard>();
        if (card) {
            if (extraThingsToSelect.Length == 0) {
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
