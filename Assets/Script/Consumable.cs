using UnityEngine;
using System.Collections;

public class Consumable : Item {
    public string Name { get; private set; }
    public int PowerValue { get; private set; }

    public Consumable(string name, int powerValue) {
        Name = name;
        PowerValue = powerValue;
    }
}
