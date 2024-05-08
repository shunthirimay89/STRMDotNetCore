﻿

namespace STRMDotNetCore.RestApiWithNLayer.Models;

[Table("Tbl_Blog")]
public class BlogModel

{
    [Key]
    public int BlogId { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogContent { get; set; }

    // public record BlogEntity(int BlogId, string BlogAuthor, string BlogTitle, string BlogContent);

}
