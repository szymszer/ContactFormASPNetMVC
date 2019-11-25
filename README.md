# ContactFormASPNetMVC

1. Requirements:
    • Visual Studio (2017 or newer)
    • MS SQL Server (2017 or newer)
    • Microsoft SQL Server Management Studio 
    • Network connection (for SMTP - email sending)
    
2. Database configuration:
Copy and Run this script to create database needed for the project.
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE DATABASE myDB1
GO
 
 USE [myDB1]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FormTable1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [varchar](15) NULL,
	[AreaOfInterest] [varchar](50) NULL,
	[Message] [varchar](max) NULL,
 CONSTRAINT [PK_FormTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

3. Visual Studio configuration:
Run '2MD_Form_SzSz.sln',
Select 'Web.Config' file,
Edit connection strings for "FormEntities" and "myDB1Entities"
Change the data source property (default: DESKTOP-KI7HRKU\SQLEXPRESS01) - insert your sql server name,
Edit 'Data Connections': View -> Server Explorer -> Data Connections (refresh if empty) -> Modify Connection.. -> Server Name: (insert your server name) -> press 'Test Connection' to verify.
If needed, update entity model

4. Running Solution:
Build project,
Run solution (or press F5 - default),
On success a new page will be shown in your default browser.
Insert form data and press 'Submit' - email and message fields are required, email verification requires valid email form (ex@example) 
Successful submit will store a record in database and send an email. If something fails there will be a message with an error.
   
