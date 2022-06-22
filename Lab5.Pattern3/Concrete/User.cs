using Lab5.Pattern3.Abstract;
using Lab5.Pattern3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Pattern3.Concrete
{
    public class User : ISubscriber
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Dictionary<Type, List<PrintedMaterial>> MaterialSubscribes { get; } = new();
        public IDeliveryHandler DeliveryHandler { get; set; }


        public void Update(IPublisher publisher)
        {
            DeliveryHandler?.Handle((PostOffice)publisher, this);
        }

        public override string ToString()
        {
            return $"\nName: {Name} Surname: {Surname}";
        }
    }
}
