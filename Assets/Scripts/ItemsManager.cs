﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ItemsManager : MonoBehaviour, IGameManager {
    public ManagerStatus status { get; private set; }

    public List<Item> ItemList;
    public Consumable HealthPotion = new Consumable("Health Potion", 25);
    public Consumable Meat = new Consumable("Meat", 0);

    public void Startup() {
        Debug.Log("Items manager starting...");

        ItemList = new List<Item>();

        ItemList.Add(HealthPotion);
        ItemList.Add(Meat);
        ItemList.Add(new Card("Jab Card", 1, Color.yellow, Color.red, Color.magenta));
        ItemList.Add(new Card("Punch Card", 2, Color.red, Color.yellow, Color.magenta));
        ItemList.Add(new Card("Kick Card", 3, Color.magenta, Color.blue, Color.grey));
        ItemList.Add(new Card("Stab Card", 4, Color.blue, Color.yellow, Color.grey));

        status = ManagerStatus.Started;
    }
}
