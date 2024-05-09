using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace STRMDotNetCore.RestApiWithNLayer.Features.LatHtaukBayDin
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatHtaukBayDinController : ControllerBase
    {

        private async Task<LatHtaukBayDin> GetDataAsync() 
        {
            string jsonStr = await System.IO. File.ReadAllTextAsync("data.json");
            var model = JsonConvert.DeserializeObject<LatHtaukBayDin>(jsonStr);
            return model;
        }

        [HttpGet("questions")]
        public async Task<IActionResult> QuestionsAsync() 
        {
            var model = await GetDataAsync();
            return Ok(model.questions);
        }

        [HttpGet]
        public async Task <IActionResult> NumberList() 
        {
            var model = await GetDataAsync();
            return Ok(model.numberList);
        }

        [HttpGet("{questionNo}/{anserwerNo}")]
        public async Task<IActionResult> Answer(int questionNo,int anserwerNo) 
        {
            var model = await GetDataAsync();
            return Ok(model.answers .FirstOrDefault(x => x.questionNo == questionNo && x.answerNo == anserwerNo));
        }

    }


    public class LatHtaukBayDin
    {
        public Question[] questions { get; set; }
        public Answer[] answers { get; set; }
        public string[] numberList { get; set; }
    }

    public class Question
    {
        public int questionNo { get; set; }
        public string questionName { get; set; }
    }

    public class Answer
    {
        public int questionNo { get; set; }
        public int answerNo { get; set; }
        public string answerResult { get; set; }
    }
}




