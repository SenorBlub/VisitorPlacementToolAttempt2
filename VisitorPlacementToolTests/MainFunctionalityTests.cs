using VisitorPlacementToolAttempt2.DataStorages;
using VisitorPlacementToolAttempt2.MainFunctionalities;
using VisitorPlacementToolAttempt2.StartingDataGenerators;

namespace VisitorPlacementToolTests
{
    public class MainFunctionalityTests : TestBase
    {
        [Fact]
        public void FillFieldsTest()
        {
            // Arrange
            List<Visitor> visitors = makeGenericGrouplessAdultVisitors(10);
            Event expectedEvent = new Event()
            {
                Fields = new List<Field>()
                {
                    new Field(new List<Row>())
                    {
                        Rows = new List<Row>()
                        {
                            new Row(new List<Visitor>())
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[0],
                                    visitors[1],
                                    visitors[2]
                                }
                            },
                            new Row(new List<Visitor>())
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[3],
                                    visitors[4],
                                    visitors[5]
                                }
                            },
                            new Row(new List<Visitor>())
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[6],
                                    visitors[7],
                                    visitors[8]
                                }
                            }
                        }
                    },
                    new Field(new List<Row>())
                    {
                        Rows = new List<Row>()
                        {
                            new Row(new List<Visitor>())
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[9],
                                    null,
                                    null,
                                    null,
                                    null
                                }
                            },
                            new Row(new List<Visitor>())
                            {
                                Visitors = new List<Visitor>()
                                {
                                    null,
                                    null,
                                    null,
                                    null,
                                    null
                                }
                            }
                        }
                    },
                }
            };

            Event inputEvent = new Event()
            {
                Visitors = visitors,
                Fields = new List<Field>()
                {
                    new Field(new List<Row>())
                    {
                        Rows = new List<Row>()
                        {
                            new Row(new List<Visitor>(3)),
                            new Row(new List<Visitor>(3)),
                            new Row(new List < Visitor >(3))
                        }
                    },
                    new Field(new List<Row>())
                    {
                        Rows = new List<Row>()
                        {
                            new Row(new List<Visitor>(5)),
                            new Row(new List<Visitor>(5))
                        }
                    }
                }
            };

            // Act
            Event actualEvent = new PlaceVisitors().FillFields(inputEvent);

            // Assert
            Assert.Equal(expectedEvent, actualEvent);
        }

        [Fact]
        public void CheckSignUpDatesTest()
        {
            // Arrange
            Event expectedEvent = new Event()
            {

            };
            Event inputEvent = new Event()
            {

            };

            // Act
            Event actualEvent = new PlaceVisitors().CheckSignUpDates(inputEvent);

            // Assert
            Assert.Equal(expectedEvent, actualEvent);
        }

        [Fact]
        public void CheckAgesAtTimeOfEventTest()
        {
            // Arrange
            Event expectedEvent = new Event()
            {

            };
            Event inputEvent = new Event()
            {

            };

            // Act
            Event actualEvent = new PlaceVisitors().CheckAgesAtTimeOfEvent(inputEvent);

            // Assert
            Assert.Equal(expectedEvent, actualEvent);
        }

        [Fact]
        public void PlaceGroupsTest()
        {
            // Arrange
            Event expectedEvent = new Event()
            {

            };
            Event inputEvent = new Event()
            {

            };

            // Act
            Event actualEvent = new PlaceVisitors().PlaceGroups(inputEvent);

            // Assert
            Assert.Equal(expectedEvent, actualEvent);
        }

        [Fact]
        public void PlaceChildrenInFrontTest()
        {
            // Arrange
            Event expectedEvent = new Event()
            {

            };
            Event inputEvent = new Event()
            {

            };

            // Act
            Event actualEvent = new PlaceVisitors().PlaceChildrenInFront(inputEvent);

            // Assert
            Assert.Equal(expectedEvent, actualEvent);
        }

        [Fact]
        public void PlaceChildrenWithAdultsTest()
        {
            // Arrange
            Event expectedEvent = new Event()
            {

            };
            Event inputEvent = new Event()
            {

            };

            // Act
            Event actualEvent = new PlaceVisitors().PlaceChildrenWithAdults(inputEvent);

            // Assert
            Assert.Equal(expectedEvent, actualEvent);
        }

        [Fact]
        public void SplitGroupsThatDoNotFitTest()
        {
            // Arrange
            Event expectedEvent = new Event()
            {

            };
            Event inputEvent = new Event()
            {

            };

            // Act
            Event actualEvent = new PlaceVisitors().SplitGroupsThatDoNotFit(inputEvent);

            // Assert
            Assert.Equal(expectedEvent, actualEvent);
        }
    }
}