using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Utils;
using System;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter(PointerEventData eventData) {
		if (eventData.pointerDrag == null)
			return;
		
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null) {

            d.placeholderParent = transform;
            try
            {
                DropZones dropZone = (DropZones)Enum.Parse(typeof(DropZones), d.placeholderParent.name);
                switch (dropZone)
                {
                    case DropZones.TABLETOP:
                        if (d.placeholderParent.childCount < 5)
                            d.isDroppable = true;
                        else d.isDroppable = false;
                        break;
                    case DropZones.DECK:
                        d.isDroppable = false;
                        break;
                    case DropZones.HAND:
                        if (d.parentToReturnTo.name == DropZones.HAND.ToString())
                            d.isDroppable = true;
                        else d.isDroppable = false;
                        break;
                    case DropZones.OPPONENT_TABLETOP:
                        d.isDroppable = false;
                        break;
                    default:
                        d.isDroppable = false;
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Debug.Log(ex);
            }
		}
	}

	public void OnDrop(PointerEventData eventData) {
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null && d.isDroppable) {
			d.parentToReturnTo = transform;
		}
	}

    public void OnPointerExit(PointerEventData eventData) {
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeholderParent == transform) {
            d.placeholderParent = d.parentToReturnTo;
        }
	}
}
