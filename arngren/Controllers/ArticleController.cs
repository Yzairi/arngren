using arngren.Commun.Model;
using arngren.Service;
using Microsoft.AspNetCore.Mvc;

namespace arngren.Controllers;
[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase
{
    private readonly ArticleService _articleService;

    public ArticleController(ArticleService articleService)
    {
        _articleService = articleService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
    {
        return await _articleService.GetArticles();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> GetArticle(int id)
    {
        var Article = await _articleService.GetArticle(id);

        if (Article == null)
        {
            return NotFound();
        }

        return Article;
    }

    [HttpPost]
    public async Task<ActionResult<Article>> PostArticle(Article Article)
    {
        await _articleService.AddArticle(Article);

        return CreatedAtAction(nameof(GetArticle), new { id = Article.Id }, Article);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutArticle(int id, Article Article)
    {
        if (id != Article.Id)
        {
            return BadRequest();
        }

        await _articleService.UpdateArticle(id, Article);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticle(int id)
    {
        var deleted = await _articleService.DeleteArticle(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
