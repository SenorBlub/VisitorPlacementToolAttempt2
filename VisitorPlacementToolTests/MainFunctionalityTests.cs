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
            List<Visitor> visitors = makeGenericGrouplessAdultVisitors(5);
            visitors.AddRange(ChangeSignDate(makeGenericGrouplessAdultVisitors(5), DateOnly.MinValue));
            Event expectedEvent = new Event()
            {
                Visitors = makeGenericGrouplessAdultVisitors(5)
            };
            Event inputEvent = new Event()
            {
                Visitors = visitors
            };

            // Act
            Event actualEvent = new PlaceVisitors().CheckSignUpDates(inputEvent);

            // Assert
            Assert.Equal(expectedEvent, actualEvent);
        }

        [Fact]
        public void CheckAgesAtTimeOfEventTest()
        {
            List<Visitor> visitors = makeGenericGrouplessAdultVisitors(5);
            visitors.AddRange(makeGenericGrouplessChildVisitors(5));
            // Arrange
            Event expectedEvent = new Event()
            {
                Visitors = makeGenericGrouplessAdultVisitors(5)
            };
            Event inputEvent = new Event()
            {
                Visitors = visitors
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
            List<Visitor> visitors = makeGenericGroupedAdultVisitors(5, 1);
            visitors.AddRange(makeGenericGroupedAdultVisitors(7, 2));
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
                                    visitors[2],
                                    visitors[3],
                                    visitors[4]
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
                    new Field(new List<Row>())
                    {
                        Rows = new List<Row>()
                        {
                            new Row(new List<Visitor>())
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[5],
                                    visitors[6],
                                    visitors[7],
                                    visitors[8],
                                    visitors[9],
                                    visitors[10],
                                    visitors[11]
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
                            new Row(new List<Visitor>(5)),
                            new Row(new List<Visitor>(5)),
                            new Row(new List < Visitor >(5))
                        }
                    },
                    new Field(new List<Row>())
                    {
                        Rows = new List<Row>()
                        {
                            new Row(new List<Visitor>(7)),
                            new Row(new List<Visitor>(7))
                        }
                    }
                }
            };

            // Act
            Event actualEvent = new PlaceVisitors().PlaceGroups(inputEvent);

            // Assert
            Assert.Equal(expectedEvent, actualEvent);
        }

        [Fact]
        public void PlaceChildrenInFrontTest() // TODO harder than rest
        {
            // Arrange
            List<Visitor> visitors = makeGenericGroupedAdultVisitors(5, 1);
            visitors.AddRange(MakeGenericGroupedMixedVisitors(3, 4, 2));
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
                                    visitors[2],
                                    visitors[3],
                                    visitors[4]
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
                    new Field(new List<Row>())
                    {
                        Rows = new List<Row>()
                        {
                            new Row(new List<Visitor>())
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[9],
                                    visitors[10],
                                    visitors[11],
                                    visitors[5],
                                    visitors[6],
                                    visitors[7],
                                    visitors[8]
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
                            new Row(new List<Visitor>(5)),
                            new Row(new List<Visitor>(5)),
                            new Row(new List < Visitor >(5))
                        }
                    },
                    new Field(new List<Row>())
                    {
                        Rows = new List<Row>()
                        {
                            new Row(new List<Visitor>(7)),
                            new Row(new List<Visitor>(7))
                        }
                    }
                }
            };

            // Act
            Event actualEvent = new PlaceVisitors().PlaceChildrenInFront(inputEvent);

            // Assert
            Assert.Equal(expectedEvent, actualEvent);
        }

        [Fact]
        public void PlaceChildrenWithAdultsTest() // TODO harder than rest
        {
            // Arrange
            List<Visitor> visitors = MakeGenericGroupedMixedVisitors(5, 2, 1);
            visitors.AddRange(MakeGenericGroupedMixedVisitors(3, 4, 2));
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
                                    visitors[2],
                                    visitors[3],
                                    visitors[4]
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
                    new Field(new List<Row>())
                    {
                        Rows = new List<Row>()
                        {
                            new Row(new List<Visitor>())
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[5],
                                    visitors[9],
                                    visitors[6],
                                    visitors[10],
                                    visitors[7],
                                    visitors[11],
                                    visitors[8]
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
                            new Row(new List<Visitor>(5)),
                            new Row(new List<Visitor>(5)),
                            new Row(new List < Visitor >(5))
                        }
                    },
                    new Field(new List<Row>())
                    {
                        Rows = new List<Row>()
                        {
                            new Row(new List<Visitor>(7)),
                            new Row(new List<Visitor>(7))
                        }
                    }
                }
            };

            // Act
            Event actualEvent = new PlaceVisitors().PlaceChildrenWithAdults(inputEvent);

            // Assert
            Assert.Equal(expectedEvent, actualEvent);
        }

        [Fact]
        public void SplitGroupsThatDoNotFitTest() // TODO harder than rest
        {
            // Arrange
            List<Visitor> visitors = makeGenericGroupedAdultVisitors(25, 1);
            visitors.AddRange(makeGenericGroupedAdultVisitors(37, 2));
            visitors.AddRange(makeGenericGroupedAdultVisitors(15, 3));
            Event expectedEvent = new Event()
            {
                Fields = new List<Field>()
                {
                    new Field(new List<Row>())
                    {
                        Rows = new List<Row>()
                        {
                            new Row(new List<Visitor>(5))
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[0],
                                    visitors[1],
                                    visitors[2],
                                    visitors[3],
                                    visitors[4]
                                }
                            },
                            new Row(new List<Visitor>(5))
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[62],
                                    visitors[63],
                                    visitors[64],
                                    visitors[65],
                                    visitors[66]
                                }
                            },
                            new Row(new List < Visitor >(5))
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[32],
                                    visitors[33],
                                    visitors[34],
                                    visitors[35],
                                    visitors[36]
                                }
                            }

                        }
                    },
                    new Field(new List<Row>())
                    {
                        Rows = new List<Row>()
                        {
                            new Row(new List<Visitor>(7))
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[25],
                                    visitors[26],
                                    visitors[27],
                                    visitors[28],
                                    visitors[29],
                                    visitors[30],
                                    visitors[31]
                                }
                            },
                            new Row(new List<Visitor>(7))
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[13],
                                    visitors[14],
                                    visitors[15],
                                    visitors[16],
                                    visitors[17],
                                    visitors[18],
                                    visitors[19]
                                }
                            }
                        }
                    },
                    new Field(new List<Row>())
                    {
                        Rows= new List<Row>()
                        {
                            new Row(new List<Visitor>(8))
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[5],
                                    visitors[6],
                                    visitors[7],
                                    visitors[8],
                                    visitors[9],
                                    visitors[10],
                                    visitors[11],
                                    visitors[12]
                                }
                            },
                            new Row(new List<Visitor>(8))
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[37],
                                    visitors[38],
                                    visitors[39],
                                    visitors[40],
                                    visitors[41],
                                    visitors[42],
                                    visitors[43],
                                    visitors[44],
                                }
                            },
                            new Row(new List<Visitor>(8))
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[60],
                                    visitors[61],
                                    visitors[62],
                                    visitors[63],
                                    visitors[64],
                                    visitors[65],
                                    visitors[72],
                                    visitors[73],
                                    visitors[74],
                                }
                            }
                        }
                    },
                    new Field(new List<Row>())
                    {
                        Rows = new List<Row>()
                        {
                            new Row(new List<Visitor>(7))
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[45],
                                    visitors[46],
                                    visitors[47],
                                    visitors[48],
                                    visitors[49],
                                    visitors[50],
                                    visitors[51]
                                }
                            },
                            new Row(new List<Visitor>(7))
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[20],
                                    visitors[21],
                                    visitors[22],
                                    visitors[23],
                                    visitors[24],
                                    visitors[75],
                                    visitors[76]
                                }
                            }
                        }
                    },
                    new Field(new List<Row>())
                    {
                        Rows = new List<Row>()
                        {
                            new Row(new List<Visitor>(5))
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[67],
                                    visitors[68],
                                    visitors[69],
                                    visitors[70],
                                    visitors[71]
                                }
                            },
                            new Row(new List<Visitor>(5))
                            {
                                Visitors = new List<Visitor>()
                                {
                                    visitors[32],
                                    visitors[33],
                                    visitors[34],
                                    visitors[35],
                                    visitors[36]
                                }
                            }
                        }
                    }
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
                            new Row(new List<Visitor>(5)),
                            new Row(new List<Visitor>(5)),
                            new Row(new List < Visitor >(5))
                        }
                    },
                    new Field(new List<Row>())
                    {
                        Rows = new List<Row>()
                        {
                            new Row(new List<Visitor>(7)),
                            new Row(new List<Visitor>(7))
                        }
                    },
                    new Field(new List<Row>())
                    {
                        Rows= new List<Row>()
                        {
                            new Row(new List<Visitor>(8)),
                            new Row(new List<Visitor>(8)),
                            new Row(new List<Visitor>(8))
                        }
                    },
                    new Field(new List<Row>())
                    {
                        Rows = new List<Row>()
                        {
                            new Row(new List<Visitor>(7)),
                            new Row(new List<Visitor>(7))
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
            Event actualEvent = new PlaceVisitors().SplitGroupsThatDoNotFit(inputEvent);

            // Assert
            Assert.Equal(expectedEvent, actualEvent);
        }
    }
}