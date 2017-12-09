using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Utils;

public class CardDrawer : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameObject.Find(DropZones.HAND.ToString()).transform.childCount < 8)
            Utils.DrawCard();
    }
}
