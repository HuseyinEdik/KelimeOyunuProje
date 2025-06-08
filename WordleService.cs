using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeOyunuProje
{
    public class WordleService
    {
        private string connectionString = "Server=YOUR_SERVER;Database=YOUR_DATABASE;Integrated Security=True;";

        public string TargetWord { get; private set; } = ""; // Anlık hedef kelime

        public void StartNewWordleGame(int userId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Bilinen 5 harfli kelimeleri çek
                string query = @"
                    SELECT W.EngWordName
                    FROM KnownWords K
                    JOIN Words W ON K.WordID = W.WordID
                    WHERE K.UserID = @UserID AND LEN(W.EngWordName) = 5";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                List<string> knownWords = new List<string>();

                while (reader.Read())
                {
                    knownWords.Add(reader.GetString(0).ToUpper());
                }

                reader.Close();

                if (knownWords.Count > 0)
                {
                    Random rnd = new Random();
                    int index = rnd.Next(knownWords.Count);
                    TargetWord = knownWords[index];
                }
                else
                {
                    throw new Exception("Henüz öğrenilmiş 5 harfli kelimeniz yok.");
                }
            }
        }

        public string CheckWordleGuess(string guess)
        {
            if (string.IsNullOrEmpty(TargetWord))
                return "Önce yeni oyun başlatın!";

            guess = guess.ToUpper();

            string feedback = "";

            for (int i = 0; i < 5; i++)
            {
                if (guess[i] == TargetWord[i])
                    feedback += guess[i] + " (Green) ";
                else if (TargetWord.Contains(guess[i]))
                    feedback += guess[i] + " (Yellow) ";
                else
                    feedback += guess[i] + " (Gray) ";
            }

            if (guess == TargetWord)
                return $"Tebrikler! Bildiniz. Kelime: {TargetWord}";

            return $"Feedback: {feedback}";
        }



    }
}
