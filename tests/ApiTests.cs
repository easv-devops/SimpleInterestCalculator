using Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service;
using Service.interfaces;
using SimpleInterestCalculator.controllers;

namespace tests;

[TestFixture]
public class Tests
{
    private Mock<IEntriesService> _mockEntriesService;
    private EntriesController _controller;
    
    [SetUp]
    public void Setup()
    {
        _mockEntriesService = new Mock<IEntriesService>();
        _controller = new EntriesController(_mockEntriesService.Object);
    }

    [Test]
    public void GetEntryByEntryIdTest()
    {
        //arrange
        var entryId = 1;
        var entry = new Entries { EntryId = entryId };

        _mockEntriesService.Setup(s => s.GetEntryByEntryId(entryId)).Returns(entry);
        
        //act
        var result = _controller.GetEntryByEntryId(entryId);
        
        //assert
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        
        Assert.That(okResult.Value, Is.EqualTo(entry));
    }

    [Test]
    public void DeleteEntryByEntryIdTest()
    {
        //arrange
        var entryId = 1;
        var entry = new Entries { EntryId = entryId };

        
        _mockEntriesService.Setup(s => s.DeleteEntry(entryId)).Returns(true);
        
        //act
        var result = _controller.DeleteEntry(entryId);
        
        //assert
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult.Value, Is.EqualTo(true));
    }
    
    [Test]
    public void AddEntryTest()
    {
        //arrange
        var entryId = 1;
        var entry = new Entries { EntryId = entryId };

        
        _mockEntriesService.Setup(s => s.AddEntry(entry)).Returns(true);
        
        //act
        var result = _controller.AddEntry(entry);
        
        //assert
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult.Value, Is.EqualTo(true));
    }

    [Test]
    public void GetEntriesByUserIdTest()
    {
        //arrange
        var userId = 1;
        var entry1 = new Entries { UserId = userId, EntryId = 1 };
        var entry2 = new Entries { UserId = userId, EntryId = 2 };
        var entriesList = new List<Entries>();
        entriesList.Add(entry1);
        entriesList.Add(entry2);

        _mockEntriesService.Setup(s => s.GetEntriesByUserId(userId)).Returns(entriesList);
        
        //act
        var result = _controller.GetEntriesByUserId(userId);
        
        //assert
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult.Value, Is.EqualTo(entriesList));
    }
    
    
}