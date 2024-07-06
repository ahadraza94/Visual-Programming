ALTER PROCEDURE registrationform
@Email varchar(50),
@Password varchar(50),
@FirstName varchar(50),
@LastName varchar(50),
@Gender varchar(50),
@DateofBirth varchar(50)
AS
BEGIN
INSERT INTO lab09
                         (Email, Password, FirstName, LastName, Gender, DateofBirth)
VALUES       (@Email,@Password,@FirstName,@LastName,@Gender,@DateofBirth)
END
GO
