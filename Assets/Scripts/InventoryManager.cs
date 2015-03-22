using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour, IGameManager {
    public ManagerStatus status { get; private set; }
    public TextMesh PotionCount;
    public TextMesh FoodCount;
    public GameObject InventoryWindow;
    public GameObject InventoryItemRow;
    private List<GameObject> _itemRowList;
    private Dictionary<Item, int> _inventoryDictionary;
    private Consumable _healthPotion;
    private Consumable _meat;
    private int _startingHealthPotionAmount = 3;
    private int _startingMeatAmount = 3;

    public void Startup() {
        Debug.Log("Inventory manager starting...");

        InventoryWindow = Instantiate(InventoryWindow, new Vector3(0, 0.45f, 0), Quaternion.identity) as GameObject;
        InventoryWindow.SetActive(false);

        _healthPotion = Managers.Items.HealthPotion;
        _meat = Managers.Items.Meat;

        _inventoryDictionary = new Dictionary<Item, int>();
        _itemRowList = new List<GameObject>();

        while (GetItemCount(_healthPotion) < _startingHealthPotionAmount) {
            AddItemToInventory(_healthPotion);
        }
        while (GetItemCount(_meat) < _startingMeatAmount) {
            AddItemToInventory(_meat);
        }

        status = ManagerStatus.Started;
    }

    public void AddItemToInventory(Item item) {
        if (_inventoryDictionary.ContainsKey(item)) {
            _inventoryDictionary[item] += 1;
        }
        else {
            _inventoryDictionary[item] = 1;
        }
        UpdateInventoryDisplay();
    }

    public void AddRandomItemToInventory() {
        Item randomItem = Managers.Items.ItemList[Random.Range(0, Managers.Items.ItemList.Count)];
        AddItemToInventory(randomItem);
        Debug.Log("Item added to inventory: " + randomItem.Name);
        UpdateInventoryDisplay();
    }

    public void ToggleInventoryWindowDisplay() {
        if (InventoryWindow.activeSelf == true) {
            InventoryWindow.SetActive(false);
        }
        else {
            InventoryWindow.SetActive(true);
        }
    }

    private void UpdateInventoryDisplay() {
        PotionCount.text = GetItemCount(_healthPotion).ToString();
        FoodCount.text = GetItemCount(_meat).ToString();

        foreach (GameObject itemRow in _itemRowList) {
            Destroy(itemRow);
        }

        float rowXPosition = -1.53f;
        float rowYPosition = 1.55f;
        float yOffset = 0.4f;

        foreach (KeyValuePair<Item, int> item in _inventoryDictionary) {
            if (item.Value > 0) {
                rowYPosition -= yOffset;
                GameObject itemRow = Instantiate(InventoryItemRow) as GameObject;
                itemRow.transform.parent = InventoryWindow.transform;
                itemRow.transform.localPosition = new Vector3(rowXPosition, rowYPosition, 0);
                itemRow.GetComponent<InventoryItemUIController>().AssignItemRowText(item.Key);
                _itemRowList.Add(itemRow);
            }
        }
    }

    public void RemoveItem(Item item) {
        if (_inventoryDictionary.ContainsKey(item)) {
            if (_inventoryDictionary[item] > 0) {
                _inventoryDictionary[item] -= 1;
            }
            else {
                _inventoryDictionary.Remove(item);
            }
        }
        else {
            Debug.Log("Cannot remove " + item.Name + ". It is not in the player's inventory.");
        }
        UpdateInventoryDisplay();
    }

    public int GetItemCount(Item item) {
        if (_inventoryDictionary.ContainsKey(item)) {
            return _inventoryDictionary[item];
        }
        return 0;
    }
}
