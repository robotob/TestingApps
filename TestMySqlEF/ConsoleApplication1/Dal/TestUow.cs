using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToB.Db.GenericRepository;

namespace ConsoleApplication1.Dal
{
    public class TestUow : IDisposable
    {
        private TestDbContext _context;
        private IGenericRepository<Pocos.Table1> _table1Repository = null;

        public TestUow(string nameOrConnectionString)
        {
            _context = new TestDbContext(nameOrConnectionString);
        }

        public IGenericRepository<Pocos.Table1> Table1Repository
        {
            get
            {
                if (_table1Repository == null)
                {
                    _table1Repository = new GenericRepository<Pocos.Table1>(_context);
                }
                return _table1Repository;
            }
        }


        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        #region [Dispose]
        private bool _disposed = false;

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_table1Repository != null)
                    {
                        _table1Repository = null;
                    }
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
