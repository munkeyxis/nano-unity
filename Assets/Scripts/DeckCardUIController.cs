using UnityEngine;
using System.Collections;

public class DeckCardUIController : MonoBehaviour {

    private Card _card;

    public void AssignItemRowText(Card card) {
        _card = card;
        transform.GetChild(0).GetComponent<TextMesh>().text = card.Name;
        transform.GetChild(1).GetComponent<TextMesh>().text = Managers.Deck.GetCardCountInDeck(card).ToString();
    }

    public void RemoveCardFromDeck() {
        if (_card is Card) {
            Managers.Deck.RemoveCardFromDeck(_card);
            Managers.Inventory.AddItemToInventory(_card);
        }
        else {
            Debug.Log("Cannot remove " + _card.Name + " to deck. It is not a Card!");
        }
    }
}
