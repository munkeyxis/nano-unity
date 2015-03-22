using System;
using UnityEngine;
using System.Collections;

public class Explore : MonoBehaviour {
        
    void OnMouseUpAsButton() {
        Managers.Inventory.RemoveItem(Managers.Items.Meat);
        // activate new Event

        // TODO: remove after testing has been completed
        // Managers.Inventory.AddRandomItemToInventory();
        Managers.CombatManager.StartCombat();
    }
}
