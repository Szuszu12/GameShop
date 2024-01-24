using AutoMapper;
using GameShop.Data;
using GameShop.Interfaces;
using GameShop.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GameShop.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GameShopContext _context;
        //private readonly IMapper _mapper;
        public CategoryRepository(GameShopContext context/*, IMapper mapper*/)
        {
            _context = context;
            //_mapper = mapper;
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public bool CreateCategory(Category category)
        {
            //Change Tracker
            // adding, updating, modifying
            // connected or disconnected
            // EntityState.Added
            // 
            _context.Add(category);
            //_context.SaveChanges();

            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        //public ICollection<Game> GetGameByCategory(int categoryId)
        //{
        //    var category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);

        //    if (category != null)
        //    {
        //        var games = _context.Games.Where(c => category.Id == c.CategoryId).ToList();
        //        return games;
        //    }

        //    // Zwracamy pustą kolekcję lub null w zależności od wymagań
        //    return new List<Game>();
        //}

        //public ICollection<Game> GetGameByCategory(int categoryId)
        //{
        //    return _context.GameCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Game).ToList();
        //}

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}
