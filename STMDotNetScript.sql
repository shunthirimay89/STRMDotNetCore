USE [STMDB]
GO
/****** Object:  Table [dbo].[Tbl_Blog]    Script Date: 23/04/2024 4:43:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogAuthor] [varchar](50) NOT NULL,
	[BlogTitle] [varchar](50) NOT NULL,
	[BlogContent] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Blog] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Blog] ON 

INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogAuthor], [BlogTitle], [BlogContent]) VALUES (1, N'Author', N'Title', N'Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogAuthor], [BlogTitle], [BlogContent]) VALUES (2, N'Author 2', N'Title 2', N'Content 2')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogAuthor], [BlogTitle], [BlogContent]) VALUES (3, N'Test Author', N'Test Title', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogAuthor], [BlogTitle], [BlogContent]) VALUES (4, N'Test Author', N'Test Title', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogAuthor], [BlogTitle], [BlogContent]) VALUES (5, N'Test Author', N'Test Title', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogAuthor], [BlogTitle], [BlogContent]) VALUES (6, N'Test Author', N'Test Title', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogAuthor], [BlogTitle], [BlogContent]) VALUES (7, N'Test Author', N'Test Title', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogAuthor], [BlogTitle], [BlogContent]) VALUES (8, N'Test Author', N'Test Title', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogAuthor], [BlogTitle], [BlogContent]) VALUES (9, N'Test Author', N'Test Title', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogAuthor], [BlogTitle], [BlogContent]) VALUES (10, N'Test Author', N'Test Title', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogAuthor], [BlogTitle], [BlogContent]) VALUES (1003, N'TestAuthor', N'TestTitle', N'TestContent')
SET IDENTITY_INSERT [dbo].[Tbl_Blog] OFF
GO
