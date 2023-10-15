CREATE DATABASE [eliteTask]
GO
USE [eliteTask]
CREATE TABLE [bill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Item_name] [nvarchar](100) NOT NULL,
	[Quntity] [int] NOT NULL,
	[Unit_price] [decimal](10, 2) NOT NULL,
	[Total] [decimal](10, 2) NOT NULL, 
)

