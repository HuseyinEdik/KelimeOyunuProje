CREATE TABLE word_samples  (
    id int  IDENTITY(1,1) PRIMARY KEY , 
    word_id int NOT NULL FOREIGN KEY REFERENCES words( id) ,
     example_text NVARCHAR(MAX) NOT NULL );
