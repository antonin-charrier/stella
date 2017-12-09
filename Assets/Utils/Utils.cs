namespace Assets.Utils
{
    class Utils
    {
        public static void DrawCard()
        {
            var deckCard = DeckCardContainer.RandomDeckCard(XmlAccessor.DeckCardContainer.Deck);
            var card = deckCard.AsCard();
            if (card != null) card.Instantiate();
        }
    }
}