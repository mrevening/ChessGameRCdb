/****** Object:  Table [dbo].[BoardConfigurationToFigure]    Script Date: 7/22/2023 1:16:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BoardConfigurationToFigure](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BoardConfigurationId] [int] NOT NULL,
	[FigureId] [int] NOT NULL,
 CONSTRAINT [PK_BoardConfigurationCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BoardConfigurationToFigure]  WITH CHECK ADD  CONSTRAINT [FK_BoardConfigurationToFigure_BoardConfiguration] FOREIGN KEY([BoardConfigurationId])
REFERENCES [dbo].[BoardConfiguration] ([Id])
GO

ALTER TABLE [dbo].[BoardConfigurationToFigure] CHECK CONSTRAINT [FK_BoardConfigurationToFigure_BoardConfiguration]
GO

ALTER TABLE [dbo].[BoardConfigurationToFigure]  WITH CHECK ADD  CONSTRAINT [FK_BoardConfigurationToFigure_Figure] FOREIGN KEY([FigureId])
REFERENCES [dbo].[Figure] ([Id])
GO

ALTER TABLE [dbo].[BoardConfigurationToFigure] CHECK CONSTRAINT [FK_BoardConfigurationToFigure_Figure]
GO

