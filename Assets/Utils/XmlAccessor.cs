namespace Assets.Utils
{
    public static class XmlAccessor
    {
        private const string CardLoaderPath = "Loader/Loaders/cards";
        private const string DeckLoaderPath = "Loader/Loaders/decks";
        private const string DeckCardLoaderPath = "Loader/Loaders/deck_cards";
        public static CardContainer CardContainer = CardContainer.Load(CardLoaderPath);
        public static DeckContainer DeckContainer = DeckContainer.Load(DeckLoaderPath);
        public static DeckCardContainer DeckCardContainer = DeckCardContainer.Load(DeckCardLoaderPath);
    }
}
