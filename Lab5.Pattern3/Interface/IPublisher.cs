using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Pattern3.Interface
{
    public interface IPublisher
    {
        public void Subscribe(ISubscriber subscriber);
        public void UnSubscribe(ISubscriber subscriber);
        public void NotifySubscribers();
    }
}
