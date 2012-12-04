using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Data
{
    public class DataContext : IDisposable
    {
        private GetsetcodeEntities _context;
        protected bool _disposed = false;

        public GetsetcodeEntities Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new GetsetcodeEntities();
                }
                return _context;
            }
        }

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed && _context != null)
            {
                if (disposing) _context.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
