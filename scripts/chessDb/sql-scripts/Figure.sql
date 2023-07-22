/****** Object:  Table [dbo].[Figure]    Script Date: 7/22/2023 1:16:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Figure](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ColorId] [int] NULL,
	[FigureTypeId] [int] NULL,
	[ColumnId] [int] NULL,
	[RowId] [int] NULL,
 CONSTRAINT [PK_Figure] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Figure]  WITH CHECK ADD  CONSTRAINT [FK_Figure_Color] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Color] ([Id])
GO

ALTER TABLE [dbo].[Figure] CHECK CONSTRAINT [FK_Figure_Color]
GO

ALTER TABLE [dbo].[Figure]  WITH CHECK ADD  CONSTRAINT [FK_Figure_Column] FOREIGN KEY([ColumnId])
REFERENCES [dbo].[Column] ([Id])
GO

ALTER TABLE [dbo].[Figure] CHECK CONSTRAINT [FK_Figure_Column]
GO

ALTER TABLE [dbo].[Figure]  WITH CHECK ADD  CONSTRAINT [FK_Figure_FigureType] FOREIGN KEY([FigureTypeId])
REFERENCES [dbo].[FigureType] ([Id])
GO

ALTER TABLE [dbo].[Figure] CHECK CONSTRAINT [FK_Figure_FigureType]
GO

ALTER TABLE [dbo].[Figure]  WITH CHECK ADD  CONSTRAINT [FK_Figure_Row] FOREIGN KEY([RowId])
REFERENCES [dbo].[Row] ([Id])
GO

ALTER TABLE [dbo].[Figure] CHECK CONSTRAINT [FK_Figure_Row]
GO

