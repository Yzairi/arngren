using arngren.Commun.Model;
using arngren.Data;
using Microsoft.EntityFrameworkCore;

namespace arngren.Service
{
    public class ArticleService
    {
        private readonly ArngrenContext _context;

        public ArticleService(ArngrenContext context)
        {
            _context = context;
        }

        public async Task<List<Article>> GetArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Article> GetArticle(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task<Article> AddArticle(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return article;
        }

        public async Task<Article> UpdateArticle(int id, Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return article;
        }

        public async Task<bool> DeleteArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return false;
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
