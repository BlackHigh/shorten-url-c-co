using Microsoft.AspNetCore.Mvc;
using shorten_gateway.Model;
using shorten_gateway.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shorten_gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortenController : ControllerBase { }

    private readonly ILogger<ShortenController> _logger;

    //Must be Interface
    private ShortenService shortenService = new ShortenService();

    public ShortenController(ILogger<ShortenController> logger)
    {
        //initial logger but won't be used at this project
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<URL>> PostLongURL(string url)
    {
        // Validate the input URL
        if (!Uri.TryCreate(url, UriKind.Absolute, out _))
        {
            return BadRequest("Invalid URL format.");
        }

        // Check if the URL already exists in the database (NOT IMPLEMENT ON THIS PROJECT
        //var existingUrl = await _dbContext.Urls.FirstOrDefaultAsync(u => u.OriginalUrl == url); 

        // Generate a unique short code
        var shortCode = shortenService.GenerateShortCode();

        // Create a new URL entity
        var newUrl = new Url
        {
            OriginalUrl = url,
            ShortCode = shortCode
        };

        // DB NOT IMPLEMENT
        //await _dbContext.Urls.AddAsync(newUrl);
        //await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUrl), new { shortCode }, newUrl);
    }

    [HttpGet("{shortCode}")]
    public async Task<ActionResult<Url>> GetUrl(string shortCode)
    {
        //var url = await _dbContext.Urls.FirstOrDefaultAsync(u => u.ShortCode == shortCode);

        var url = shortCode;

        if (url == null)
        {
            return NotFound();
        }

        return Ok(url);
    }
}