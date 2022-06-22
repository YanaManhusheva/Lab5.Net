using Lab5.Pattern3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Pattern3.Concrete
{
    public abstract class BaseDeliveryHandler : IDeliveryHandler
    {
        private IDeliveryHandler _nextHandler;
        public virtual void Handle(PostOffice postOffice, User user)
        {
            if (_nextHandler is not null)
                _nextHandler.Handle(postOffice, user);
        }

        public IDeliveryHandler SetNext(IDeliveryHandler handler)
        {
            _nextHandler = handler;
            return _nextHandler;
        }
    }
}
