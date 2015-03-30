using UnityEngine;
using System.Collections;

public class DragTransform : MonoBehaviour {
    private bool _dragging = false;
    private bool _inDropArea = false;
    private Vector3 _originalPosition;

    void Start() {
        _originalPosition = transform.localPosition;
    }

    void OnMouseDown() {
        _dragging = true;
    }

    void OnMouseUp() {
        _dragging = false;

        if (!_inDropArea) {
            transform.localPosition = _originalPosition;
        }
    }

    void Update() {
        if (_dragging) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            transform.position = new Vector3(ray.origin.x, ray.origin.y, transform.position.z);
        }
    }

    void OnTriggerEnter2D() {
        _inDropArea = true;
    }

    void OnTriggerStay2D() {
        if (!_dragging) {
            GetComponent<DroppableObject>().UseObject();
        }
    }

    void OnTriggerExit2D() {
        _inDropArea = false;
    }
}
