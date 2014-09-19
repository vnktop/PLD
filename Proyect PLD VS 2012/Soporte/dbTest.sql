USE [master]
GO

/****** Object:  Table [dbo].[dbTest]    Script Date: 09/18/2014 22:15:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[dbTest](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbTest] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

insert into [dbTest] ([Descripcion] ) values ('Descripcion 1')
insert into [dbTest] ([Descripcion] ) values ('Descripcion 2')
insert into [dbTest] ([Descripcion] ) values ('Descripcion 3')

select * from [dbTest]

