﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace STRMDotNetCore.RestApi.Models;

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
