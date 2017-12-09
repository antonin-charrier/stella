using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Utils;

public class CardPicker : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var deckCard = DeckCardContainer.RandomDeckCard(XmlAccessor.DeckCardContainer.Deck);
        var card = deckCard.AsCard();
        if (card != null) card.Instantiate();
    }
}
