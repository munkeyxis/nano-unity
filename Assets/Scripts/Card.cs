using UnityEngine;
using System.Collections;

public class Card : Item {
    public string Name { get; private set; }
    private int _powerValue;
    public Color CardColor { get; private set; }
    public Color ComboColor { get; private set; }

    public Card(string name, int powerValue, Color cardColor, Color comboColor) {
        Name = name;
        _powerValue = powerValue;
        CardColor = cardColor;
        ComboColor = comboColor;
    }

    public int getPowerValue() {
        return _powerValue;
    }
}
