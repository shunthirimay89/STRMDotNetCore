using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace STRMDotNetCore.RestApiWithNLayer.Features.DreamDictionary
{
    [Route("api/[controller]")]
    [ApiController]
    public class DreamDictionaryController : ControllerBase
    {
        private async Task<DreamDictionary> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("DreamDictionary.json");
            var model = JsonConvert.DeserializeObject<DreamDictionary>(jsonStr);
            return model;
        }

        [HttpGet("blogHeader")]
        public async Task<IActionResult> BlogHeader()
        {
            var model = await GetDataAsync();
            return Ok(model.BlogHeader);
        }

        [HttpGet]
        public async Task<IActionResult> BlogDetail()
        {
            var model = await GetDataAsync();
            return Ok(model.BlogDetail);
        }

        [HttpGet("{blogId}/{blodDetailId}")]
        public async Task<IActionResult> BlogContent(int blogId, int blodDetailId)
        {
            var model = await GetDataAsync();
            return Ok(model.BlogDetail.FirstOrDefault(x => x.BlogId == blogId && x.BlogDetailId== blodDetailId));
        }

    }



    public class DreamDictionary
    {
        public Blogheader[] BlogHeader { get; set; }
        public Blogdetail[] BlogDetail { get; set; }
    }

    public class Blogheader
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
    }

    public class Blogdetail
    {
        public int BlogDetailId { get; set; }
        public int BlogId { get; set; }
        public string BlogContent { get; set; }
    }

}
