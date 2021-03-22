using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empite_Dot_Net.Data
{
	public static class Constants
	{
		public const string AddUser = @"OPEN SYMMETRIC KEY UserInfo_Key DECRYPTION BY CERTIFICATE UserInfo;
																		INSERT INTO 
																			Users
																			(
																				Type, 
																				EncryptedFirstName, 
																				EncryptedLastName, 
																				Password, 
																				Email
																			)
																		VALUES
																			(
																				@type, 
																				EncryptByKey(Key_GUID('UserInfo_Key'), CONVERT(varchar,@firstname)), 
																				EncryptByKey(Key_GUID('UserInfo_Key'), CONVERT(varchar,@lastname)), 
																				@password, 
																				@email
																			);
																		CLOSE SYMMETRIC KEY UserInfo_Key;
																		";

		public const string UpdateUser = @"OPEN SYMMETRIC KEY UserInfo_Key DECRYPTION BY CERTIFICATE UserInfo;
																			 UPDATE Users 
																			 SET 
																				Type=@type,
																				EncryptedFirstName=EncryptByKey(Key_GUID('UserInfo_Key'), CONVERT(varchar, @firstname)), 
																				EncryptedLastName=EncryptByKey(Key_GUID('UserInfo_Key'), CONVERT(varchar, @lastname)), 
																				Password=@password
																				IsActive=@active
																			 WHERE 
																				Email=@email;
																			 CLOSE SYMMETRIC KEY UserInfo_Key;
																			 ";

		public const string GetAllUsers = @"OPEN SYMMETRIC KEY UserInfo_Key DECRYPTION BY CERTIFICATE UserInfo;
																				SELECT
																					Id,
																					Type,
																					CONVERT(varchar, DecryptByKey(EncryptedFirstName)) AS FirstName,
																					CONVERT(varchar, DecryptByKey(EncryptedLastName)) AS LastName,
																					EncryptedFirstName,
																					EncryptedLastName,
																					Password,
																					Email,
																					IsActive
																				FROM Users;
																				CLOSE SYMMETRIC KEY UserInfo_Key;";

		public const string GetUserByEmail = @"SELECT
																							Id,
																							Type,
																							CONVERT(varchar, DecryptByKey(EncryptedFirstName)) AS FirstName,
																							CONVERT(varchar, DecryptByKey(EncryptedLastName)) AS LastName,
																							EncryptedFirstName,
																							EncryptedLastName,
																							Password,
																							Email,
																							IsActive
																						FROM Users 
																						WHERE Email=@email;
																						CLOSE SYMMETRIC KEY UserInfo_Key;";
	}
}
