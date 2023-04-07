using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrostructure.Infrostructure
{
    public class CreateDatabase
    {
        static string constringForBooks = GetConnection.Connection();
        public void CreateBaseIfNot()
        {
            //create base Books  
            string conStringForPostgres = GetConnection.Connection().Replace("books", "postgres");
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conStringForPostgres))
                {

                    conn.Open();
                    conn.Execute("Create database books;");

                }

                using (NpgsqlConnection conn = new NpgsqlConnection(constringForBooks))
                {
                    conn.Open();
                    CreateTablesIfnot();
                }

            }
            catch (NpgsqlException e)
            {
                
                CreateTablesIfnot();

            }


        }


        public async void CreateTablesIfnot()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(constringForBooks))
                {
                    conn.Open();
                    string commandText = @"
                                        create table book(
                                        book_id serial primary key,
                                        book_name varchar(100) not null,
                                        book_author varchar(100) not null,
                                        book_count integer not null,
                                        book_came_times timestamp default now(),
                                        book_sell_count integer default 0
                                        );";
                    CommandDefinition commandDefinition = new(commandText);

                    await conn.ExecuteAsync(commandDefinition);

                }
            }
            catch (NpgsqlException e)
            {

            }

        }
    }
}
