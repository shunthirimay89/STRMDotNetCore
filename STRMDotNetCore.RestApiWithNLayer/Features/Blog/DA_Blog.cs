using STRMDotNetCore.RestApiWithNLayer.Db;
using System.Reflection.Metadata;

namespace STRMDotNetCore.RestApiWithNLayer.Features.Blog
{
    public class DA_Blog
    {
        private readonly AppDbContext _dbContext;

        public DA_Blog() 
        {
            _dbContext = new AppDbContext();
        }

        public List<BlogModel> GetBlogs() 
        {
            var list = _dbContext.blogs.ToList();
            return list;
        }

        public BlogModel? GetBlog(int id) 
        {
            BlogModel? item =_dbContext.blogs.FirstOrDefault(x=> x.BlogId == id);
            return item;
        }

        public int CreateBlog(BlogModel requestModel) 
        {
            _dbContext.blogs.Add(requestModel);
            int result = _dbContext.SaveChanges();
            return result;
       
        }

        public int updateBlog(int id, BlogModel requestModel)
        {
            var item =_dbContext.blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) 
            {
                return 0;
            }
            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogTitle = requestModel.BlogTitle;
            item.BlogContent = requestModel.BlogContent;

            _dbContext.blogs.Add(requestModel);
            int result = _dbContext.SaveChanges();
            return result;
        }

        public int patchBlog(int id, BlogModel requestModel) 
        {
            var item = _dbContext.blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return 0;
            }
            if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
            {

                item.BlogAuthor = requestModel.BlogAuthor;
            }

            if (!string.IsNullOrEmpty(requestModel.BlogTitle))
            {

                item.BlogTitle = requestModel.BlogTitle;
            }

            if (!string.IsNullOrEmpty(requestModel.BlogContent))
            {

                item.BlogContent = requestModel.BlogContent;
            }
            var result = _dbContext.SaveChanges();
            return result;
        }

        public int deleteBlog(int id) 
        {
            var item = _dbContext.blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return 0;
            }
            _dbContext.blogs.Remove(item);
            int result = _dbContext.SaveChanges();
            return result;
        }
        
    }
}
