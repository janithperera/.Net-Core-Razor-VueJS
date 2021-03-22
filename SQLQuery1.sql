CREATE MASTER KEY ENCRYPTION BY   
PASSWORD = 'empite-test-pass-321';  

CREATE CERTIFICATE UserInfo  
   WITH SUBJECT = 'User Information';  
GO  

CREATE SYMMETRIC KEY UserInfo_Key  
    WITH ALGORITHM = AES_256  
    ENCRYPTION BY CERTIFICATE UserInfo;  
GO  

ALTER TABLE Users  
    ADD EncryptedFirstName varbinary(128);   
GO

ALTER TABLE Users  
    ADD EncryptedLastName varbinary(128);   
GO 

OPEN SYMMETRIC KEY UserInfo_Key  
   DECRYPTION BY CERTIFICATE UserInfo; 

UPDATE Users  
SET EncryptedFirstName = EncryptByKey(Key_GUID('UserInfo_Key'), NationalIDNumber);  
GO  

OPEN SYMMETRIC KEY UserInfo_Key
DECRYPTION BY CERTIFICATE UserInfo;
INSERT INTO Users (Type, FirstName, LastName, EncryptedFirstName, EncryptedLastName, Password, Email)
VALUES ('Admin', 'Janith', 'Perera', EncryptByKey( Key_GUID('UserInfo_Key'), CONVERT(varchar,'Janith')), EncryptByKey( Key_GUID('UserInfo_Key'), CONVERT(varchar,'Perera')), 'jc123','jccandro@gmail.com');
Go   

CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](10) NOT NULL,
	[FirstName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[EncryptedFirstName] [varbinary](128) NULL,
	[EncryptedLastName] [varbinary](128) NULL,
	[Password] [text] NOT NULL,
	[Email] [nvarchar](255) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

select * from Users;
delete from Users where Email='jccandro@gmail.com';

SELECT
CONVERT(varchar, DecryptByKey(EncryptedFirstName)) AS EncryptedFirstName,
CONVERT(varchar, DecryptByKey(EncryptedLastName)) AS EncryptedLastName
FROM Users;