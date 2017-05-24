using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public enum dropZones {HAND, TABLETOP, DECK}

	public void OnPointerEnter(PointerEventData eventData) {
		if (eventData.pointerDrag == null)
			return;
		
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null) {
			d.placeholderParent = this.transform;
			if (d.placeholderParent.name == dropZones.TABLETOP.ToString ()) {
				d.isDroppable = true;
			} else if (d.placeholderParent.name == dropZones.DECK.ToString ()) {
				d.isDroppable = false;
			} else if (d.placeholderParent.name == dropZones.HAND.ToString ()) {
				d.isDroppable = false;
			} else {
				d.isDroppable = false;
			}
		}
	}

	public void OnDrop(PointerEventData eventData) {
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		Debug.Log (d.parentToReturnTo.name);
		if (d != null && d.isDroppable) {
			d.parentToReturnTo = this.transform;
			Debug.Log (d.parentToReturnTo.name);
		}
	}

	public void OnPointerExit(PointerEventData eventData) {
		if (eventData.pointerDrag == null)
			return;
		
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null && d.placeholderParent==this.transform) {
			d.placeholderParent = d.parentToReturnTo;
		}
	}
}
