using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Demo2
{
    public class DisposableClass : IDisposable
    {
        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                //OPERAZIONI DI "CHIUSURA" DELLA RISORSA
            }
            _disposed = true;
        }
    }
}
