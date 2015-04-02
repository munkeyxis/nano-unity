using UnityEngine;
using System.Collections;

public class Card : Item {
    public string Name { get; private set; }
    private int _powerValue;
    public Color Color { get; private set; }

    public Card(string name, int powerValue, Color color) {
        Name = name;
        _powerValue = powerValue;
        Color = color;
    }

    public int getPowerValue() {
        return _powerValue;
    }
}
