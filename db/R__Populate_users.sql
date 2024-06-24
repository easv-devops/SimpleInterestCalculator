INSERT INTO Users (Email, Password)
VALUES ('admin@mail.dk', 'adminpassword')
ON CONFLICT (Email) DO UPDATE
SET Email = EXCLUDED.Email,
    Password = EXCLUDED.Password;
