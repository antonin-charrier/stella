using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;

    public bool isDroppable = false;

	GameObject placeholder = null;

	public void OnBeginDrag(PointerEventData eventData) {
        placeholder = new GameObject
        {
            name = "CardPlaceholder"
        };
        placeholder.transform.SetParent (transform.parent );
		LayoutElement le = placeholder.AddComponent<LayoutElement> ();
		le.preferredWidth = GetComponent<LayoutElement>().preferredWidth;
		le.preferredHeight = GetComponent<LayoutElement>().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;
		placeholder.transform.SetSiblingIndex (transform.GetSiblingIndex ());

		parentToReturnTo = transform.parent;
		placeholderParent = parentToReturnTo;
        transform.SetParent (transform.parent.parent);
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData) {
        transform.position = eventData.position;
		if (placeholder.transform.parent != placeholderParent && isDroppable)
			placeholder.transform.SetParent (placeholderParent);

        if (isDroppable)
        {
            int newSiblingIndex = placeholderParent.childCount;
            for (int i = 0; i < placeholderParent.childCount; i++)
            {
                if (transform.position.x < placeholderParent.GetChild(i).position.x)
                {
                    newSiblingIndex = i;
                    if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                        newSiblingIndex--;
                    break;
                }
            }

            placeholder.transform.SetSiblingIndex(newSiblingIndex);
        }

    }

	public void OnEndDrag(PointerEventData eventData) {
        transform.SetParent (parentToReturnTo);
        transform.SetSiblingIndex (placeholder.transform.GetSiblingIndex ());
		GetComponent<CanvasGroup> ().blocksRaycasts = true;

		Destroy (placeholder);
	}

}
