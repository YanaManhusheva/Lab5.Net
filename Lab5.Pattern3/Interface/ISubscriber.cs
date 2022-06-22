using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Pattern3.Interface
{
    public interface ISubscriber
    {
        public void Update(IPublisher publisher);
    }
}
