using System;
using System.Data.SqlClient;

namespace SqlDZ11
{
    class Program
    {
        static void Main(string[] args)
        {
            string conString = @"Data Source=localhost; Initial Catalog=schoolAlif;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            bool sss = true;
            while (sss)
            {
                Console.WriteLine("" +
           "1.Добавить\n" +
           "2.Удалить\n" +
           "3.Выбрать всё\n" +
           "4.Выбрать один по Id\n" +
           "5.Обновлять\n" +
           "6.Выход");
                string vibor = Console.ReadLine();
                switch (vibor)
                {
                    case "1": InsertPerson(con); break;
                    case "2": DeletePerson(con); break;
                    case "3": SelectAll(con); break;
                    case "4": SelestIdList(con); break;
                    case "5": break;
                    case "6": sss = false; break;


                }


            }

        }

        static void InsertPerson(SqlConnection con)/// Метод для добавление Информации в базу данных
        {
            Console.Clear();
            Console.Write("Фамилия:");
            string SureName = Console.ReadLine();
            Console.Write("Имя:");
            string Name = Console.ReadLine();
            Console.Write("отчество:");
            string MiddleName = Console.ReadLine();
            Insert(SureName, Name, MiddleName, con);

        }

        static void Insert(string Name, string SureName, string MiddleName, SqlConnection con) // Метод добавление информации клиента с доступам  базы данных
        {
            con.Open();
            string date = $"{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}";
            string insertSqlCommand = string.Format($"insert into Person([LastName],[FirstName],[MiddleName],[BirthDate]) Values('{SureName}', '{Name}','{MiddleName}',{date}) ");
            SqlCommand command = new SqlCommand(insertSqlCommand, con);
            command = new SqlCommand(insertSqlCommand, con);
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.Clear();
                Console.WriteLine("Успешно добавлена");
                Console.WriteLine($"Фамилия: {Name} Имя:{SureName} Отчество: {MiddleName} ");
                Console.WriteLine();


            }
            con.Close();



        }
        static void DeletePerson(SqlConnection con)
        {
            Console.Clear();
            SelectAll(con);

            Console.WriteLine("выберите ID из списка для удаление пользователя");
            int id = int.Parse(Console.ReadLine());
            Delete(id, con);


        }
        static void Delete(int id, SqlConnection con)
        {
            con.Open();
            string commaText = ($"Delete from Person where id={id}");
            SqlCommand command = new SqlCommand(commaText, con);
            command = new SqlCommand(commaText, con);
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {

                Console.WriteLine($"Пользователь с таким ID: {id} успешно удалена");
                Console.WriteLine();

            }

            con.Close();



        }

        static void SelectAll(SqlConnection con)
        {
            con.Open();
            string SelectList = "Select *from Person";
            SqlCommand command = new SqlCommand(SelectList, con);
            command = new SqlCommand(SelectList, con);
            var resul = command.ExecuteReader();
            while (resul.Read())
            {
                Console.WriteLine($"ID:{resul.GetValue(0)},Фамилия:{resul.GetValue(1)}, Имя:{resul.GetValue(2)}, Отчество:{resul.GetValue(3)}, Дата рождения:{resul.GetValue(4)}");
            }
            con.Close();





        }
        static void SelestIdList(SqlConnection con)
        {
            SelectAll(con);
            Console.WriteLine("Выберите Id из списка");
            int idInfo = int.Parse(Console.ReadLine());
            SelestId(idInfo,con);




        }
        static void SelestId(int idInfo, SqlConnection con)
        {
            con.Open();
            string selectidList = ($"Select * from Person where id={idInfo}");
            SqlCommand command = new SqlCommand(selectidList, con);
            SqlDataReader reader1 = command.ExecuteReader();
            while (reader1.Read())
            {
                Console.WriteLine($"ID:{reader1.GetValue(0)}, Фамилия:{reader1.GetValue(1)}, Имя:{reader1.GetValue(2)}, Отчество:{reader1.GetValue(3)}, Год рождения:{reader1.GetValue(4)}");
            }
        }






    }
}

