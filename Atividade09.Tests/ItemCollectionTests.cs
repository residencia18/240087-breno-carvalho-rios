namespace Atividade09.Tests
{
    public class ItemCollectionTests
    {
        [Fact]
        public void AddItem_WithValidItem_AddsItemToCollection()
        {
            var collection = new ItemCollection();
            var item = new Item("item1");

            collection.AddItem(item);

            Assert.Contains(item, collection.GetItems());
        }

        [Fact]
        public void AddItem_WithNullItem_ThrowsArgumentException()
        {
            var collection = new ItemCollection();

            Assert.Throws<ArgumentException>(() => collection.AddItem(null));
        }

        [Fact]
        public void RemoveItem_WithExistingItem_RemovesItemFromCollection()
        {
            var collection = new ItemCollection();
            var item = new Item("item1");

            collection.AddItem(item);
            collection.RemoveItem(item);

            Assert.DoesNotContain(item, collection.GetItems());
        }

        [Fact]
        public void RemoveItem_WithNonExistingItem_ThrowsArgumentException()
        {
            var collection = new ItemCollection();
            var item = new Item("item1");

            Assert.Throws<ArgumentException>(() => collection.RemoveItem(item));
        }
    }
}