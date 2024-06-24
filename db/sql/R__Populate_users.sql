INSERT INTO Users (Email, Password) VALUES 
    ('admin@mail.dk', 'adminpassword')
    ON DUPLICATE KEY UPDATE Email=Email, Password=Password;