using UnityEngine;
using System.Collections;

public class InventoryItemUIController : MonoBehaviour {

    private Item _item;

    public void AssignItemRowText(Item item) {
        _item = item;
        transform.GetChild(0).GetComponent<TextMesh>().text = item.Name;
        transform.GetChild(1).GetComponent<TextMesh>().text = Managers.Inventory.GetItemCount(item).ToString();
    }

    public void AddCardToDeck() {
        if (_item is Card) {
            Managers.Deck.AddCardToDeck(_item as Card);
            Managers.Inventory.RemoveItem(_item);
        }
        else {
            Debug.Log("Cannot add " + _item.Name + " to deck. It is not a Card!");
        }
    }
}
