using UnityEngine;
using System.Collections;

public class CardUIController : MonoBehaviour, DroppableObject {
    private Card _card;
    public TextMesh TitleTextMesh;
    public SpriteRenderer BackgroundSprite;
    public SpriteRenderer ComboColorSprite;

    public void AssignCard(Card card) {
        _card = card;
        TitleTextMesh.text = card.Name;
        BackgroundSprite.color = card.CardColor;
        ComboColorSprite.color = card.ComboColor;
    }

    public void UseObject() {
        Managers.CombatManager.UseCard(_card);
    }
}
