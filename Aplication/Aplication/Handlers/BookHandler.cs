using Domein.Domein;
using Infrostructure.Infrostructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Aplication.Aplication.Handlers
{
    public class BookHandler 
    {
        DbCoonectAplication dBcontext = new DbCoonectAplication();
        public async Task<bool> DeleteById(int id)
        {
            try
            {
                await dBcontext.DbBook.DeleteById(id);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

               return false;
            }
            
        }

        public async Task<List<Books>> GetAll()
        {
            try
            {
                return await dBcontext.DbBook.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Books>();
               
            }
           
        }

        public async Task<Books> GetById(int id)
        {
            try
            {
                return await dBcontext.DbBook.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Books();
             
            }
        }

        public async Task<bool> Insert(Books entity)
        {
            try
            {
                return await dBcontext.DbBook.Insert(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> Update(Books entity)
        {
            try
            {
                return await dBcontext.DbBook.Update(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
