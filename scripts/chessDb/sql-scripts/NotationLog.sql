/****** Object:  Table [dbo].[NotationLog]    Script Date: 7/22/2023 1:16:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotationLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GameId] [int] NOT NULL,
	[StartColumnId] [int] NOT NULL,
	[StartRowId] [int] NOT NULL,
	[EndColumnId] [int] NOT NULL,
	[EndRowId] [int] NOT NULL,
	[Castle] [bit] NULL,
	[EnPassant] [bit] NULL,
	[PromotedFigureId] [int] NULL,
	[Check] [bit] NULL,
 CONSTRAINT [PK_NotationLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[NotationLog]  WITH CHECK ADD  CONSTRAINT [FK_NotationLog_ColumnEnd] FOREIGN KEY([EndColumnId])
REFERENCES [dbo].[Column] ([Id])
GO

ALTER TABLE [dbo].[NotationLog] CHECK CONSTRAINT [FK_NotationLog_ColumnEnd]
GO

ALTER TABLE [dbo].[NotationLog]  WITH CHECK ADD  CONSTRAINT [FK_NotationLog_ColumnStart] FOREIGN KEY([StartColumnId])
REFERENCES [dbo].[Column] ([Id])
GO

ALTER TABLE [dbo].[NotationLog] CHECK CONSTRAINT [FK_NotationLog_ColumnStart]
GO

ALTER TABLE [dbo].[NotationLog]  WITH CHECK ADD  CONSTRAINT [FK_NotationLog_FigureType] FOREIGN KEY([PromotedFigureId])
REFERENCES [dbo].[FigureType] ([Id])
GO

ALTER TABLE [dbo].[NotationLog] CHECK CONSTRAINT [FK_NotationLog_FigureType]
GO

ALTER TABLE [dbo].[NotationLog]  WITH CHECK ADD  CONSTRAINT [FK_NotationLog_Game] FOREIGN KEY([GameId])
REFERENCES [dbo].[Game] ([Id])
GO

ALTER TABLE [dbo].[NotationLog] CHECK CONSTRAINT [FK_NotationLog_Game]
GO

ALTER TABLE [dbo].[NotationLog]  WITH CHECK ADD  CONSTRAINT [FK_NotationLog_RowEnd] FOREIGN KEY([EndRowId])
REFERENCES [dbo].[Row] ([Id])
GO

ALTER TABLE [dbo].[NotationLog] CHECK CONSTRAINT [FK_NotationLog_RowEnd]
GO

ALTER TABLE [dbo].[NotationLog]  WITH CHECK ADD  CONSTRAINT [FK_NotationLog_RowStart] FOREIGN KEY([StartRowId])
REFERENCES [dbo].[Row] ([Id])
GO

ALTER TABLE [dbo].[NotationLog] CHECK CONSTRAINT [FK_NotationLog_RowStart]
GO

