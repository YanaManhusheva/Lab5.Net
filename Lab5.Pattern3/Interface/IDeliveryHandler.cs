using Lab5.Pattern3.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Pattern3.Interface
{
    public interface IDeliveryHandler
    {
        public IDeliveryHandler SetNext(IDeliveryHandler handler);
        public void Handle(PostOffice postOffice, User user);
    }
}
