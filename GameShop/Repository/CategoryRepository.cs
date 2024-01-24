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

        public CategoryRepository(GameShopContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public bool CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            return Save();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(e => e.Id == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            return Save();
        }
    }
}