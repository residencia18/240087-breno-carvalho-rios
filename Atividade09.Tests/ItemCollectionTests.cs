using Xunit;

namespace Atividade09.Tests;

public class ItemCollectionTests
{

    [Fact]
    public void AddItem_ShouldReturnSuccess()
    {
        var _sut = new ItemCollection();
        var item = new Item("Item 1");

        try {
            _sut.AddItem(item);
        } catch (Exception e){
            Assert.Fail("Expected no exception, but got: " + e.Message);
        }
    }

    [Fact]
    public void AddItem_NullItem_ShouldReturnError()
    {
        var _sut = new ItemCollection();
        Item? item = null!;

        var error = Assert.Throws<ArgumentException>(() => _sut.AddItem(item));
        Assert.Contains("Item cannot be null", error.Message);
    }

    [Fact]
    public void RemoveItem_ShouldReturnSuccess()
    {
        var _sut = new ItemCollection();
        var item = new Item("Item 1");
        _sut.AddItem(item);

        try {
            _sut.RemoveItem(item);
        } catch (Exception e){
            Assert.Fail("Expected no exception, but got: " + e.Message);
        }
    }

    [Fact]
    public void RemoveItem_ItemNotFound_ShouldReturnError()
    {
        var _sut = new ItemCollection();
        var item = new Item("Item 1");

        var error = Assert.Throws<ArgumentException>(() => _sut.RemoveItem(item));
        Assert.Contains("Item not found in the collection", error.Message);
    }

    [Fact]
    public void GetItems_ShouldReturnItems()
    {
        var _sut = new ItemCollection();
        var item1 = new Item("Item 1");
        var item2 = new Item("Item 2");

        _sut.AddItem(item1);
        _sut.AddItem(item2);

        var items = _sut.GetItems();

        Assert.Equal(2, items.Count);
        Assert.Equal("Item 1", item1.Name);
        Assert.Equal("Item 2", item2.Name);
    }
}