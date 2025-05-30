CREATE TABLE user_progress (
     id int IDENTITY(1,1) PRIMARY KEY,
    user_id int NOT NULL FOREIGN KEY REFERENCES users(id), -- ikincil anahtarlar önemli--
    word_id int NOT NULL FOREIGN KEY REFERENCES words(id),
    correct_count int DEFAULT 0,
    last_answer_date DATE );
