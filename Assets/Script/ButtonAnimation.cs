using UnityEngine;
using System.Collections;

public class ButtonAnimation : MonoBehaviour {
    public Sprite ButtonUpSprite;
    public Sprite ButtonDownSprite;

    void OnMouseDown() {
        GetComponent<SpriteRenderer>().sprite = ButtonDownSprite;
    }

    void OnMouseUp() {
        GetComponent<SpriteRenderer>().sprite = ButtonUpSprite;
    }
}
