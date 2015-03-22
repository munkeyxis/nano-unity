using UnityEngine;
using System.Collections;

public class AddToDeckButton : MonoBehaviour {

    void OnMouseUpAsButton() {
        transform.parent.parent.GetComponent<InventoryItemUIController>().AddCardToDeck();
    }
}
