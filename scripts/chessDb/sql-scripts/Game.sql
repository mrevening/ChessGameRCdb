/****** Object:  Table [dbo].[Game]    Script Date: 7/22/2023 1:16:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Game](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BoardConfigurationId] [int] NOT NULL,
	[HostColorId] [int] NULL,
	[HostId] [nvarchar](max) NULL,
	[HostName] [nvarchar](max) NULL,
	[HostToken] [nvarchar](max) NULL,
	[GuestId] [nvarchar](max) NULL,
	[GuestName] [nvarchar](max) NULL,
	[GuestToken] [nvarchar](max) NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK_Game_BoardConfiguration] FOREIGN KEY([BoardConfigurationId])
REFERENCES [dbo].[BoardConfiguration] ([Id])
GO

ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK_Game_BoardConfiguration]
GO

ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK_Game_Color] FOREIGN KEY([HostColorId])
REFERENCES [dbo].[Color] ([Id])
GO

ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK_Game_Color]
GO

