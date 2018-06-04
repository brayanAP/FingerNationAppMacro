using FingerNationAppMacro.Helpers;
using FingerNationAppMacro.interfaces;
using FingerNationAppMacro.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FingerNationAppMacro.services
{
    public class SrvFingerNation : ISrvFingerNation
    {
        /*VARIABLES DE MANEJO*/
        private static readonly AsyncLock aMutex = new AsyncLock();
        private SQLiteAsyncConnection sqliteconnection;

        public SrvFingerNation()
        {
            var databasePath = DependencyService.Get<IPathServiceSqlite>().GetDatabasePath();
            sqliteconnection = new SQLiteAsyncConnection(databasePath);
            CreateDataBaseAsync();
        }//Constructor

        public async void CreateDataBaseAsync()
        {
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                await sqliteconnection.CreateTableAsync<Categorias>(CreateFlags.None).ConfigureAwait(false);
                await sqliteconnection.CreateTableAsync<Alimentos>(CreateFlags.None).ConfigureAwait(false);
                await sqliteconnection.CreateTableAsync<Usuario>(CreateFlags.None).ConfigureAwait(false);
                await sqliteconnection.CreateTableAsync<Macronutrientes>(CreateFlags.None).ConfigureAwait(false);
                await sqliteconnection.CreateTableAsync<Logros>(CreateFlags.None).ConfigureAwait(false);
                await sqliteconnection.CreateTableAsync<ConsumoDia>(CreateFlags.None).ConfigureAwait(false);
                await sqliteconnection.CreateTableAsync<ConteoConsumoDiaAlimento>(CreateFlags.None).ConfigureAwait(false);

                    


                
            }
        }//CreateDataBaseAsync

        #region DELETE

        public async Task DeleteAlimentos(Alimentos item)
        {
            await sqliteconnection.DeleteAsync(item);
        }

        public async Task DeleteCategorias(Categorias item)
        {
            await sqliteconnection.DeleteAsync(item);
        }

        public async Task DeleteConsumoDia(ConsumoDia item)
        {
            await sqliteconnection.DeleteAsync(item);
        }

        public async Task DeleteConteoConsumoDiaAlimento(ConteoConsumoDiaAlimento item)
        {
            await sqliteconnection.DeleteAsync(item);
        }

        public async Task DeleteLogros(Logros item)
        {
            await sqliteconnection.DeleteAsync(item);
        }

        public async Task DeleteMacronutrientes(Macronutrientes item)
        {
            await sqliteconnection.DeleteAsync(item);
        }

        public async Task DeleteUsuario(Usuario item)
        {
            await sqliteconnection.DeleteAsync(item);
        }
        #endregion

        #region SELECT ALL

        public async Task<IList<Alimentos>> GetAllAlimentos()
        {
            var items = new List<Alimentos>();
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                items = await sqliteconnection.Table<Alimentos>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task<IList<Categorias>> GetAllCategorias()
        {
            var items = new List<Categorias>();
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                items = await sqliteconnection.Table<Categorias>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task<IList<ConsumoDia>> GetAllConsumoDia()
        {
            var items = new List<ConsumoDia>();
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                items = await sqliteconnection.Table<ConsumoDia>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task<IList<ConteoConsumoDiaAlimento>> GetAllConteoConsumoDiaAlimento()
        {
            var items = new List<ConteoConsumoDiaAlimento>();
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                items = await sqliteconnection.Table<ConteoConsumoDiaAlimento>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task<IList<Logros>> GetAllLogros()
        {
            var items = new List<Logros>();
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                items = await sqliteconnection.Table<Logros>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task<IList<Macronutrientes>> GetAllMacronutrientes()
        {
            var items = new List<Macronutrientes>();
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                items = await sqliteconnection.Table<Macronutrientes>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task<IList<Usuario>> GetAllUsuario()
        {
            var items = new List<Usuario>();
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                items = await sqliteconnection.Table<Usuario>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }
        #endregion

        #region SELECT ID

        public async Task<Alimentos> GetIdAlimentos(int id)
        {
            var items = new Alimentos();
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                var query = (from p in sqliteconnection.Table<Alimentos>()
                             where p.id == id
                             select p);

                items = await query.FirstAsync();
            }

            return items;
        }

        public async Task<Categorias> GetIdCategorias(int id)
        {
            var items = new Categorias();
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                var query = (from p in sqliteconnection.Table<Categorias>()
                             where p.id == id
                             select p);

                items = await query.FirstAsync();
            }

            return items;
        }

        public async Task<ConsumoDia> GetIdConsumoDia(int id)
        {
            var items = new ConsumoDia();
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                var query = (from p in sqliteconnection.Table<ConsumoDia>()
                             where p.id == id
                             select p);

                items = await query.FirstAsync();
            }

            return items;
        }

        public async Task<ConteoConsumoDiaAlimento> GetIdConteoConsumoDiaAlimento(int id)
        {
            var items = new ConteoConsumoDiaAlimento();
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                var query = (from p in sqliteconnection.Table<ConteoConsumoDiaAlimento>()
                             where p.id == id
                             select p);

                items = await query.FirstAsync();
            }

            return items;
        }

        public async Task<Logros> GetIdLogros(int id)
        {
            var items = new Logros();
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                var query = (from p in sqliteconnection.Table<Logros>()
                             where p.id == id
                             select p);

                items = await query.FirstAsync();
            }

            return items;
        }

        public async Task<Macronutrientes> GetIdMacronutrientes(int id)
        {
            var items = new Macronutrientes();
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                var query = (from p in sqliteconnection.Table<Macronutrientes>()
                             where p.id == id
                             select p);

                items = await query.FirstAsync();
            }

            return items;
        }

        public async Task<Usuario> GetIdUsuario(int id)
        {
            var items = new Usuario();
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                var query = (from p in sqliteconnection.Table<Usuario>()
                             where p.id == id
                             select p);

                items = await query.FirstAsync();
            }

            return items;
        }
        #endregion

        #region INSERT

        public async Task DropTableAlimentos()
        {
            await sqliteconnection.DropTableAsync<Alimentos>();
        }
        public async Task InsertAlimentos(Alimentos item)
        {
          
            bool insertado = true;
            var lista = await sqliteconnection.Table<Alimentos>().ToListAsync().ConfigureAwait(false);
            var it = new Alimentos();

                foreach(Alimentos a in lista)
                {
                    if (a.nombre == item.nombre)
                    {
                        insertado = false;
                        it = a;
                    }
                }

                if (insertado)
                {
                    await sqliteconnection.InsertAsync(item).ConfigureAwait(false);
                }
                else
                {
                    item.id = it.id;
                    await sqliteconnection.UpdateAsync(item).ConfigureAwait(false);
                }
            
        }
            
        public async Task InsertCategorias(Categorias item)
        {
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                var existingTodoItem = await sqliteconnection.Table<Categorias>()
                        .Where(x => x.nombre == item.nombre)
                        .FirstOrDefaultAsync();

                if (item == null)
                {
                    await sqliteconnection.InsertAsync(item).ConfigureAwait(false);
                }
                else
                {
                    item.id = item.id;
                    await sqliteconnection.UpdateAsync(item).ConfigureAwait(false);
                }
            }
        }

        public async Task InsertConsumoDia(ConsumoDia item)
        {
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                var existingTodoItem = await sqliteconnection.Table<ConsumoDia>()
                        .Where(x => x.id == item.id)
                        .FirstOrDefaultAsync();

                if (item == null)
                {
                    await sqliteconnection.InsertAsync(item).ConfigureAwait(false);
                }
                else
                {
                    item.id = item.id;
                    await sqliteconnection.UpdateAsync(item).ConfigureAwait(false);
                }
            }
        }

        public async Task InsertConteoConsumoDiaAlimento(ConteoConsumoDiaAlimento item)
        {
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                var existingTodoItem = await sqliteconnection.Table<ConteoConsumoDiaAlimento>()
                        .Where(x => x.id == item.id)
                        .FirstOrDefaultAsync();

                if (item == null)
                {
                    await sqliteconnection.InsertAsync(item).ConfigureAwait(false);
                }
                else
                {
                    item.id = item.id;
                    await sqliteconnection.UpdateAsync(item).ConfigureAwait(false);
                }
            }
        }

        public async Task InsertLogros(Logros item)
        {
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                var existingTodoItem = await sqliteconnection.Table<Logros>()
                        .Where(x => x.id == item.id)
                        .FirstOrDefaultAsync();

                if (item == null)
                {
                    await sqliteconnection.InsertAsync(item).ConfigureAwait(false);
                }
                else
                {
                    item.id = item.id;
                    await sqliteconnection.UpdateAsync(item).ConfigureAwait(false);
                }
            }
        }

        public async Task InsertMacronutrientes(Macronutrientes item)
        {
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                var existingTodoItem = await sqliteconnection.Table<Macronutrientes>()
                        .Where(x => x.id == item.id)
                        .FirstOrDefaultAsync();

                if (item == null)
                {
                    await sqliteconnection.InsertAsync(item).ConfigureAwait(false);
                }
                else
                {
                    item.id = item.id;
                    await sqliteconnection.UpdateAsync(item).ConfigureAwait(false);
                }
            }
        }

        public async Task InsertUsuario(Usuario item)
        {
            using (await aMutex.LockAsync().ConfigureAwait(false))
            {
                var existingTodoItem = await sqliteconnection.Table<Usuario>()
                        .Where(x => x.id == item.id)
                        .FirstOrDefaultAsync();

                if (item == null)
                {
                    await sqliteconnection.InsertAsync(item).ConfigureAwait(false);
                }
                else
                {
                    item.id = item.id;
                    await sqliteconnection.UpdateAsync(item).ConfigureAwait(false);
                }
            }
        }
        #endregion
    }
}
