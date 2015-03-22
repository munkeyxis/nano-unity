using UnityEngine;
using System.Collections;

public class RemoveFromDeckButton : MonoBehaviour {

    void OnMouseUpAsButton() {
        transform.parent.parent.GetComponent<DeckCardUIController>().RemoveCardFromDeck();
    }
}
