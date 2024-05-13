using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AcademyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;";

string[] modules = {"Основы программирования на языке С++",
                    "Разработка приложений на языке Python",
                    "Объектно-ориентированное программирование на С++",
                    "Платформа .NET и язык программирования C#",
                    "Паттерны проектирования",
                    "Теория баз данных",
                    "Основы растровой графики и приложение Adobe Photoshop",
                    "Основы композиции",
                    "Моделирование объектов в приложении 3d Max",
                    "Векторная графика и редактор Adobe Illustrator",
                    "Анимация трехмерная в Blender",
                    "Основы языков разметки html и таблиц стилей css",
                    "Язык программирования JavaScript",
                    "Создание шаблонов с помощью css-фреймворков Bootstrap, Material UI"
};

string[] groups = { "ПВ 221",
"ПВ 312",
"ПВ 130",
"ДВ 220",
"ВЕБ 14",
"ЛДВ 112",
"П 15",
"СПУ 230",
"СПД 320",
"ВДД 211",
"ВДУ 330",
"ДВ 123"
 };

//string commandString = $@"INSERT INTO Module
//                              (title)
//                              VALUES
//                              (@title)";

string commandString = $@"INSERT INTO [Group]
                              (title)
                              VALUES
                              (@title)";

using (var connection = new SqlConnection(connectionString))
{
    await connection.OpenAsync();

    var command = connection.CreateCommand();
    command.CommandText = commandString;

    command.Parameters.Add("@title", SqlDbType.NVarChar);

    //foreach (var param in modules)
    //{
    //    command.Parameters["@title"].Value = $"{param}";
    //    await command.ExecuteNonQueryAsync();
    //}

    foreach (var param in groups)
    {
        command.Parameters["@title"].Value = $"{param}";
        await command.ExecuteNonQueryAsync();
    }


}