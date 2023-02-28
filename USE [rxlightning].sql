USE [rxlightning]

CREATE TABLE [dbo].[Patients](
	[patientId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](60) NOT NULL,
	[lastName] [varchar](30) NOT NULL,
	[gender] [varchar](30) NOT NULL,
	[dateOfBirth] [datetime] NOT NULL,
	[addressLine1] [varchar](60) NOT NULL,
	[addressLine2] [varchar](60) NOT NULL,
	[city] [varchar](30) NOT NULL,
	[state] [varchar](30) NOT NULL,
	[postalCode] [varchar](2) NOT NULL,
	CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED
	(
		[patientId] ASC
	)
)


INSERT [dbo].[Patients] VALUES (N'James', N'Holden', N'Male',  CAST(N'2022-01-17 14:47:58.207' AS DateTime), N'123 Fake Street', N'Suite 300',  N'Baltimore',  N'MD',  N'50109')


#########

USE [rxlightning]

CREATE TABLE [dbo].[Patients](
	[patientId] [UNIQUEIDENTIFIER] PRIMARY KEY DEFAULT NEWID(),
	[firstName] NVARCHAR(30),
    [lastName] NVARCHAR(30),
    [gender] NVARCHAR(10),
    [dateOfBirth] DATETIME,
    [addressLine1] NVARCHAR(20),
    [addressLine2] NVARCHAR(20),
    [city] NVARCHAR(10),
    [state] NVARCHAR(2),
    [postalCode] NVARCHAR(20),
)

INSERT [dbo].[Patients] VALUES('James', 'Holden', 'Male', CAST(N'1950-12-25' AS Date), '123 Fake Street', 'Suite 300', 'Baltimore', 'MD', '50109');

INSERT INTO rxlightning.dbo.Patients
( firstName, lastName, gender, dateOfBirth, addressLine1, addressLine2, city, state, postalCode)
VALUES( 'Sebastian', 'Garcia', 'Male', CAST(N'1995-11-29' AS Date), 'Calle 53', '15-56', 'Cali', 'VA', '760001');

INSERT INTO rxlightning.dbo.Patients
( firstName, lastName, gender, dateOfBirth, addressLine1, addressLine2, city, state, postalCode)
VALUES( 'Amos', 'Burton', 'Male', CAST(N'03/25/1953' AS Date), '456 North Avenue', null, 'New York', 'NY', '00152');

INSERT INTO rxlightning.dbo.Patients
( firstName, lastName, gender, dateOfBirth, addressLine1, addressLine2, city, state, postalCode)
VALUES( 'Naomi', 'Nagata', 'Female', CAST(N'06/15/1975' AS Date), '89 South Circle', 'Apt 3B', 'Louisville', 'KY', '30158');

INSERT INTO rxlightning.dbo.Patients
( firstName, lastName, gender, dateOfBirth, addressLine1, addressLine2, city, state, postalCode)
VALUES( 'Alex', 'Kamal', 'Male', CAST(N'07/03/1963' AS Date), '5894 NW 115th Street', null, 'Iowa City', 'IA', '52333');

INSERT INTO rxlightning.dbo.Patients ( firstName, lastName, gender, dateOfBirth, addressLine1, addressLine2, city, state, postalCode)
VALUES( 'Chrisjen', 'Avasarala', 'Female', CAST(N'01/09/1945"' AS Date), '8956 Oak Street', null, 'San Diego', 'CA', '90210');

INSERT INTO rxlightning.dbo.Patients ( firstName, lastName, gender, dateOfBirth, addressLine1, addressLine2, city, state, postalCode)
VALUES( 'Clarissa', 'Mao', 'Female', CAST(N'06/08/1985' AS Date), '3845 Lakeview Drive', 'Unit 37 Leftnull', 'Chicago', 'IL', '40589');