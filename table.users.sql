CREATE TABLE users (
    id INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(100) UNIQUE NOT NULL,

     password NVARCHAR(100) NOT NULL );

insert into users values (null , 'admin','12345');
