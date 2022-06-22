using Lab5.Pattern3.Abstract;
using Lab5.Pattern3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Pattern3.Concrete
{
    public class PostOffice : IPublisher
    {
        private readonly List<ISubscriber> _subscribers = new();
        public List<PrintedMaterial> PrintedMaterials { get; } = new();
        public Dictionary<User, List<PrintedMaterial>> DeliveryDictionary { get; } = new();

        public void Subscribe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void UnSubscribe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }
        public void NotifySubscribers()
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(this);
            }
        }

        public void RecieveMaterial(List<PrintedMaterial> printedMaterials)
        {
            PrintedMaterials.AddRange(printedMaterials);
            if (PrintedMaterials.Any())
                NotifySubscribers();
        }
        public void Deliver(PrintedMaterial printedMaterial, User user)
        {
            if (PrintedMaterials.Remove(printedMaterial))
            {
                if (!DeliveryDictionary.ContainsKey(user))
                {
                    DeliveryDictionary.Add(user, new List<PrintedMaterial> { printedMaterial });
                }
                else
                {
                    DeliveryDictionary[user].Add(printedMaterial);
                }
            }

        }

    }
}
