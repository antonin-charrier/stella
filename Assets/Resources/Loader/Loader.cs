using Assets.Utils;
using UnityEngine;

public class Loader : MonoBehaviour
{
    void Start() 
    {
        var deck = XmlAccessor.DeckContainer.Decks[0];
        DeckCreator.CreateXmlDeckCards(deck, XmlAccessor.CardContainer.Cards);

        for (int i = 0; i < 10; i++)
        {
            var deckCard = DeckCardContainer.RandomDeckCard(XmlAccessor.DeckCardContainer.Deck);
            var card = deckCard.AsCard();
            if (card != null) card.Instantiate();
        }
    }
}
