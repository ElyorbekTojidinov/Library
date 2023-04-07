using Domein.Domein;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Infrostructure.Infrostructure
{
    public class DbBooks : IRepository<Books>
    {
        private readonly string _connectionString;
        public DbBooks()
        {
            _connectionString = GetConnection.Connection();
        }
        public async Task DeleteById(int id)
        {

            using (NpgsqlConnection conn = new(_connectionString))
            {
                await conn.OpenAsync();
                await conn.ExecuteAsync(@"delete from book where book_id = @bookId", id);

            }
        }

        public async Task<List<Books>> GetAll()
        {
            using (NpgsqlConnection conn = new(_connectionString))
            {

                await conn.OpenAsync();
                List<Books> books = (await conn.QueryAsync<Books>(@"select book_id as BookId,
                                                       book_name as BookName,
                                                       book_author as Author,
                                                       book_count as BookCount,
                                                       book_came_times as CameTimes,
                                                       book_sell_count as SelBookCount
                                                       from book;")).ToList();

                return books;
            }

        }

        public async Task<Books> GetById(int bookId)
        {
            using (NpgsqlConnection conn = new(_connectionString))
            {
                conn.Open();
                return await conn.QueryFirstOrDefaultAsync<Books>(@"select book_id as BookId,
                                                       book_name as BookName,
                                                       book_author as Author,
                                                       book_count as BookCount,
                                                       book_came_times as CameTimes,
                                                       book_sell_count as SelBookCount
                                                             from book where book_id = @book_id", bookId );
            }
        }

        public async Task<bool> Insert(Books book)
        {
            using (NpgsqlConnection conn = new(_connectionString))
            {
                conn.Open();
                string cmdText = @"insert into book(book_name, book_author, book_count, book_came_times, book_sell_count)
                                   values(@BookName, @Author, @BookCount, @CameTimes, @SelBookCount)";
                
                if (await conn.ExecuteAsync(cmdText, book) > 0) return true;
                return false;



            }
        }

        public async Task<bool> Update(Books book)
        {
            await using (NpgsqlConnection conn = new(_connectionString))
            {
                conn.Open();
                string cmdText = @"update book set book_name = @BookName, book_author = @Author, book_count =  @BookCount, book_came_times=@CameTimes, book_sell_count= @SelBookCount
                                    where book_id = @BookId";
                if (await conn.ExecuteAsync(cmdText, book) > 0) return true;
                return false;

            }

        }
    }
}
