using UnityEngine;
using System.Collections;

public class CardUIController : MonoBehaviour, DroppableObject {
    private Card _card;

    public void AssignCard(Card card) {
        _card = card;
        transform.GetChild(0).GetComponent<TextMesh>().text = card.Name;
    }

    public void UseObject() {
        Managers.CombatManager.UseCard(_card);
    }
}
