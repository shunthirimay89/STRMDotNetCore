using STRMDotNetCore.Shared;
using STRMDotNetCore.WinFormsApp1.Queries;
using STRMDotNetCore.WinFormsApp1.Services;
using System.Configuration;

namespace STRMDotNetCore.WinFormsApp1
{
    public partial class FrmBlog : Form
    {
        private readonly DapperService _dapperService;
        public FrmBlog()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog=new BlogModel();
                blog.BlogTitle=txtTitle.Text.Trim();
                blog.BlogAuthor=txtAuthor.Text.Trim();
                blog.BlogContent=txtContent.Text.Trim();
                int result= _dapperService.Execute(BlogQueries.BlogCreate, blog) ;
                string message = result > 0 ? "saving successful" : "saving fail";
                var messageBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show(message, "Blog", MessageBoxButtons.OK, messageBoxIcon );
                if (result > 0)
                    ClearControls();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }

            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();

            txtTitle.Focus();
        }
    }
}
