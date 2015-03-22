using UnityEngine;
using System.Collections;

public class CardUIController : MonoBehaviour {
    private Card _card;

    public void AssignCard(Card card) {
        _card = card;
        transform.GetChild(0).GetComponent<TextMesh>().text = card.Name;
    }
}
