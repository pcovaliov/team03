USE [twitter]
GO
/****** Object:  Table [dbo].[Follows]    Script Date: 5/4/2015 3:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Follows](
	[id_follow] [int] IDENTITY(1,1) NOT NULL,
	[id_subscriber] [int] NOT NULL,
	[id_followed_user] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_follow] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tweets]    Script Date: 5/4/2015 3:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tweets](
	[id_tweet] [int] IDENTITY(1,1) NOT NULL,
	[descripton] [varchar](140) NULL,
	[id_user] [int] NOT NULL,
	[created_on] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tweet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/4/2015 3:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](20) NULL,
	[last_name] [varchar](20) NULL,
	[email] [varchar](50) NOT NULL,
	[avatar] [varchar](max) NULL,
	[userPassword] [varchar](35) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
