using UnityEngine;
using System.Collections;

public class UseCardButton : MonoBehaviour {
    void OnMouseUpAsButton() {
        transform.parent.parent.GetComponent<CardUIController>().UseCard();
    }
}
