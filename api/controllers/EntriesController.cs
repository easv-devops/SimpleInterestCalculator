using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.interfaces;

namespace SimpleInterestCalculator.controllers;

[ApiController]
public class EntriesController : ControllerBase
{
    private readonly IEntriesService _service;

    public EntriesController(IEntriesService service)
    {
        _service = service;
    }

    [Route("api/usersentries")]
    [HttpGet]
    public IActionResult GetEntriesByUserId(int userId)
    {
        try
        {
            var entriesList = _service.GetEntriesByUserId(userId);
            if (entriesList == null)
            {
                return NotFound();
            }

            return Ok(entriesList);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }

    }

    [Route("api/entry")]
    [HttpGet]
    public IActionResult GetEntryByEntryId(int entryId)
    {
        try
        {
            var entry = _service.GetEntryByEntryId(entryId);
            if (entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("api/addentry")]
    [HttpPost]
    public IActionResult AddEntry(Entries entry)
    {
        try
        {
            var result = _service.AddEntry(entry);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("api/deleteentry")]
    [HttpDelete]
    public IActionResult DeleteEntry(int entryId)
    {
        try
        {
            var result = _service.DeleteEntry(entryId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }
}