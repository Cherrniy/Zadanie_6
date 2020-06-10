using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Zadanie5.Controller
{
    class Query
    {
        OleDbConnection connection; //Подключение к проэкту БД
        OleDbCommand command; // Вставка удалени редактирование
        OleDbDataAdapter dataAdapter; // Получение данных из БД
        DataTable buffertTable;

        public Query(string Conn)//(Строка подключения)
        {
            connection = new OleDbConnection(Conn);
            buffertTable = new DataTable();
        }

        //метод обновления данных в таблице
        
        public DataTable UpdatePerson()
        {
            
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Person",connection);

            // Очищаем от старых данных
            buffertTable.Clear();
            // Добавляем новые
            dataAdapter.Fill(buffertTable);
            connection.Close();
            return buffertTable;
        }

        //метод добавления данных в таблице
        public void Add(string FirstName, string LastName, int Gru)
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO Person(FirstName, LastName, Gru) VALUES(@FirstName, @LastName, Gru)", connection);
            command.Parameters.AddWithValue("FirstName", FirstName);
            command.Parameters.AddWithValue("LastName", LastName);
            command.Parameters.AddWithValue("Gru", Gru);
            command.ExecuteNonQuery();
            connection.Close();
        }

        //метод удаления данных в таблице
        public void Delete(int ID)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM Person WHERE ID = {ID}", connection);           

            // Выполняем сам запрос
            command.ExecuteNonQuery();//Возвращает колличество затронутых строк
            connection.Close();
        }

        // Таблица с оценками
        public DataTable UpdatePersonO()
        {

            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Otcenc", connection);

            // Очищаем от старых данных
            buffertTable.Clear();
            // Добавляем новые
            dataAdapter.Fill(buffertTable);
            connection.Close();
            return buffertTable;
        }

        public void InsertO(int ID, int Phy, int Mat, int Com)
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO Otcenc(Id, Phy, Mat, Com) VALUES(ID, Phy, Mat, Com)", connection);
            command.Parameters.AddWithValue("ID", ID);
            command.Parameters.AddWithValue("Phy", Phy);
            command.Parameters.AddWithValue("Mat", Mat);
            command.Parameters.AddWithValue("Com", Com);
            command.ExecuteNonQuery();
            connection.Close();

        }
        public void DeleteO(int ID)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM Otcenc WHERE ID = {ID}", connection);

            // Выполняем сам запрос
            command.ExecuteNonQuery();//Возвращает колличество затронутых строк
            connection.Close();
        }
        //Поиск люди
        public DataTable PoiskP(int ID)
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter($"SELECT ID, FirstName, LastName, Gru FROM Person WHERE ID = {ID}", connection);

            // Очищаем от старых данных
            buffertTable.Clear();
            // Добавляем новые
            dataAdapter.Fill(buffertTable);
            connection.Close();
            return buffertTable;
        }
        //Поиск Оценки
        public DataTable PoiskO(int ID)
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter($"SELECT ID, Phy, Mat, Com FROM Otcenc WHERE ID = {ID}", connection);

            // Очищаем от старых данных
            buffertTable.Clear();
            // Добавляем новые
            dataAdapter.Fill(buffertTable);
            connection.Close();
            return buffertTable;
        }        
    }
}
