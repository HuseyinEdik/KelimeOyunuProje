CREATE TABLE settings  (
 id int IDENTITY(1,1 ) PRIMARY KEY ,
  user_id int not NULL FOREIGN KEY REFERENCES users(id),  --ikincil anahtar yanlış olabilir kontrol edeceğiz--
 daily_limit int DEFAULT 10 );
