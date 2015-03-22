using UnityEngine;
using System.Collections;

public class DisplayInventory : MonoBehaviour {
    
    void OnMouseUpAsButton() {
        Managers.Inventory.ToggleInventoryWindowDisplay();
    }
}
