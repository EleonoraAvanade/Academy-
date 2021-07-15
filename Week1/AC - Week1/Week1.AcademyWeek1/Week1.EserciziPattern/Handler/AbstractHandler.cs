using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EserciziPattern.Entities;

namespace Week1.EserciziPattern.Handler
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;
        public virtual double Handle(Employee employee)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(employee);
            }
            else
            {
                return 0;
            }
        }

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }
    }
}
