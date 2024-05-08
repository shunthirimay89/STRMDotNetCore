namespace STRMDotNetCore.RestApiWithNLayer.Features.Blog
{
    public class BL_Blog
    {
        private readonly DA_Blog _daBlog;

        public BL_Blog() 
        {
            _daBlog = new DA_Blog();
        }

        public List<BlogModel> GetBlogs() 
        {
            return _daBlog.GetBlogs();
        }
        public BlogModel? GetBlog(int id) 
        {
            return _daBlog.GetBlog(id);
        }
        public int CreateBlog(BlogModel requestModel) 
        {
            return _daBlog.CreateBlog(requestModel);
        }
        public int UpdateBlog(int id, BlogModel requestModel) 
        {
            return _daBlog.updateBlog(id, requestModel);
        }

        public int patchBlog(int id, BlogModel requestModel) 
        {
            return _daBlog.patchBlog(id, requestModel);
        }
        public int DeleteBlog(int id) 
        {
            return _daBlog.deleteBlog(id);
        }
    }
}
