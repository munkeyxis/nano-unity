using UnityEngine;
using System.Collections;

public class Card : Item {
    public string Name { get; private set; }
    private int _powerValue;

    public Card(string name, int powerValue) {
        Name = name;
        _powerValue = powerValue;
    }

    public int getPowerValue() {
        return _powerValue;
    }
}
