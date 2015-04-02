using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckManager : MonoBehaviour, IGameManager {
    public ManagerStatus status { get; private set; }
    public GameObject DeckCardRow;
    private List<GameObject> _deckRowList;
    private Dictionary<Card, int> _deckDictionary;
    private int _startingCard1Amount = 6;
    private int _startingCard2Amount = 2;
    private int _startingCard3Amount = 2;

    public void Startup() {
        Debug.Log("Deck manager starting...");

        _deckDictionary = new Dictionary<Card, int>();
        _deckRowList = new List<GameObject>();

        Card card1 = Managers.Items.ItemList[2] as Card;
        while (GetCardCountInDeck(card1) < _startingCard1Amount) {
            AddCardToDeck(card1);
        }

        Card card2 = Managers.Items.ItemList[3] as Card;
        while (GetCardCountInDeck(card2) < _startingCard2Amount) {
            AddCardToDeck(card2);
        }

        Card card3 = Managers.Items.ItemList[4] as Card;
        while (GetCardCountInDeck(card3) < _startingCard3Amount) {
            AddCardToDeck(card3);
        }

        status = ManagerStatus.Started;
    }
    
    public void AddCardToDeck(Card card) {
        if (_deckDictionary.ContainsKey(card)) {
            _deckDictionary[card] += 1;
        }
        else {
            _deckDictionary[card] = 1;
        }
        UpdateDeckDisplay();
    }

    public void RemoveCardFromDeck(Card card) {
        if (_deckDictionary.ContainsKey(card)) {
            if (_deckDictionary[card] > 0) {
                _deckDictionary[card] -= 1;
            }
            else {
                _deckDictionary.Remove(card);
            }
        }
        else {
            Debug.Log("Cannot remove " + card.Name + ". It is not in the player's deck.");
        }
        UpdateDeckDisplay();
    }

    public int GetCardCountInDeck(Card card) {
        if (_deckDictionary.ContainsKey(card)) {
            return _deckDictionary[card];
        }
        return 0;
    }

    private void UpdateDeckDisplay() {
        foreach (GameObject cardRow in _deckRowList) {
            Destroy(cardRow);
        }

        float rowXPosition = 1.47f;
        float rowYPosition = 1.55f;
        float yOffset = 0.4f;

        foreach (KeyValuePair<Card, int> card in _deckDictionary) {
            if (card.Value > 0) {
                rowYPosition -= yOffset;
                GameObject cardRow = Instantiate(DeckCardRow) as GameObject;
                cardRow.transform.parent = Managers.Inventory.InventoryWindow.transform;
                cardRow.transform.localPosition = new Vector3(rowXPosition, rowYPosition, 0);
                cardRow.GetComponent<DeckCardUIController>().AssignItemRowText(card.Key);
                _deckRowList.Add(cardRow);
            }
        }
    }

    public List<Card> GetDeckCardList() {
        List<Card> deckList = new List<Card>();

        foreach (KeyValuePair<Card, int> card in _deckDictionary) {
            int i = 0;
            while (i < card.Value) {
                deckList.Add(card.Key);
                i++;
            }
        }

        return deckList;
    }
}
