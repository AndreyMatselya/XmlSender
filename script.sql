USE [XmlSender]
GO
/****** Object:  Table [dbo].[Response]    Script Date: 08.07.2014 0:28:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Response](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Xml_Id] [uniqueidentifier] NOT NULL,
	[Cover] [xml] NOT NULL,
	[Errors] [xml] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[Identif] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Response] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Xml]    Script Date: 08.07.2014 0:28:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Xml](
	[Id] [uniqueidentifier] NOT NULL,
	[SendDate] [datetime] NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[XmlBody] [xml] NOT NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Xml] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Response]  WITH CHECK ADD  CONSTRAINT [FK_Response_Xml] FOREIGN KEY([Xml_Id])
REFERENCES [dbo].[Xml] ([Id])
GO
ALTER TABLE [dbo].[Response] CHECK CONSTRAINT [FK_Response_Xml]
GO
