using UnityEngine;
using System.Collections;

public class ConsumeHealthPotion : MonoBehaviour {

    void OnMouseDown() {
        if (Managers.Inventory.GetItemCount(Managers.Items.HealthPotion) > 0) {
            Managers.Player.ChangeHealth(Managers.Items.HealthPotion.PowerValue);
            Managers.Inventory.RemoveItem(Managers.Items.HealthPotion);
        }
    }

}
