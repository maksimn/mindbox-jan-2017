using System.Linq;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MindboxJan2017;

[TestClass]
public class TravelSorterTests {
    [TestMethod]
    public void Sort_MethodParameterIsNull_ReturnsNull() {
        var result = TravelSorter.Sort(null);

        Assert.IsNull(result);
    }
    
    [TestMethod]
    public void Sort_CollectionWithSingleElement_ReturnsCollectionWithThisElement() {
        var cards = new TravelCard[] { new TravelCard("a", "b") };

        var result = TravelSorter.Sort(cards);

        var expected = new TravelCard[] { new TravelCard("a", "b") };
        Assert.IsTrue(
            result.SequenceEqual<TravelCard>(expected)
        );
    }

    [TestMethod]
    public void Sort_ThreeElementsAndInverseOrder_ReturnOrderedCollection() {
        var cards = new TravelCard[] {
            new TravelCard("c", "d"), new TravelCard("b", "c"), new TravelCard("a", "b")
        };

        var result = TravelSorter.Sort(cards);

        var expected = new TravelCard[] {
            new TravelCard("a", "b"), new TravelCard("b", "c"), new TravelCard("c", "d")
        };

        Assert.IsTrue(
            result.SequenceEqual<TravelCard>(expected)
        );
    }
        
    [TestMethod]
    public void FindStartOfTravel_MethodParameterIsNull_ReturnsNull() {
        var result = TravelSorter.FindStartOfTravel(null);

        Assert.IsNull(result);
    }

    [TestMethod]
    public void FindStartOfTravel_CollectionWithSingleElement_ReturnsStartPropertyValue() {
        var cards = new TravelCard[] { new TravelCard("a", "b") };

        var result = TravelSorter.FindStartOfTravel(cards);
        
        Assert.AreEqual("a", result);
    }

    [TestMethod]
    public void FindStartOfTravel_ThreeElementsInverseOrder_ReturnsCorrectValue() {
        var cards = new TravelCard[] {
            new TravelCard("c", "d"), new TravelCard("b", "c"), new TravelCard("a", "b")
        };

        var result = TravelSorter.FindStartOfTravel(cards);

        Assert.AreEqual("a", result);
    }
}
