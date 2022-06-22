using Lab5.Pattern3.Abstract;
using Lab5.Pattern3.Concrete;
using Lab5.Pattern3.ConcreteMaterials;
using Lab5.Pattern3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5.Pattern3
{
    class Program
    {
        static void Main(string[] args)
        {
            PostOffice postOffice = new PostOffice();
            var magazineList = GetListOfMagazines();
            var newspaperList = GetListOfNewspapers();
            var subscribersList = GetListOfSubscribers(magazineList, newspaperList);
            SubscribeUsersToPost(postOffice, subscribersList);
            postOffice.RecieveMaterial(magazineList.Concat(newspaperList).Concat(magazineList).Concat(newspaperList).ToList());
            
            foreach (var user in postOffice.DeliveryDictionary)
            {
                Console.WriteLine(user.Key);
                foreach (var material in user.Value)
                {
                    Console.WriteLine(material);
                }
            }

        }


        public static List<PrintedMaterial> GetListOfMagazines()
        {
            var magazineList = new List<PrintedMaterial>
            {
                new Magazine {Name = "VOGUE", CompanyName = "Vogue"},
                new Magazine {Name = "LEGO creater", CompanyName = "Lego"},
                new Magazine {Name = "Ukrainian gardian", CompanyName = "ABC production"},
                new Magazine {Name = "Forbes Ukraine", CompanyName = "Forbes"}
            };
            return magazineList;
        }

        public static List<PrintedMaterial> GetListOfNewspapers()
        {
            var newspaperList = new List<PrintedMaterial>
            {
                new Newspaper{Name = "Sybota", EditorName ="Stepan Radchenko"},
                new Newspaper{Name = "Nedilya", EditorName ="Mykola Khvuloviy"},
                new Newspaper{Name = "Voice of Ukaine", EditorName ="Maryna Zavhorodnya"},
                new Newspaper{Name = "Den`", EditorName ="Olya Poltavska"}
            };
            return newspaperList;
        }

        public static List<ISubscriber> GetListOfSubscribers(List<PrintedMaterial> magazineList, List<PrintedMaterial> newspaperList)
        {
            var handlers = GetListOfHandlers();
            User userMagazine = new()
            {
                DeliveryHandler = handlers[0],
                Name = "Olya",
                Surname ="Hoi"
            };
            userMagazine.MaterialSubscribes.Add(typeof(Magazine), new List<PrintedMaterial> { magazineList[0], magazineList[2] });

            User userNewspaper = new()
            {
                DeliveryHandler = handlers[1],
                Name = "David",
                Surname = "Hoi"
            };
            userNewspaper.MaterialSubscribes.Add(typeof(Newspaper), new List<PrintedMaterial> { newspaperList[0], newspaperList[1] });


            User userMagazineNewspaper = new()
            {
                DeliveryHandler = handlers[2],
                Name = "Margo",
                Surname = "Semurga"
            };
            userMagazineNewspaper.MaterialSubscribes.Add(typeof(Newspaper), new List<PrintedMaterial> { newspaperList[3] });
            userMagazineNewspaper.MaterialSubscribes.Add(typeof(Magazine), new List<PrintedMaterial> { magazineList[0] });

            User userNewspaperMagazine = new()
            {
                DeliveryHandler = handlers[3],
                Name = "Angela",
                Surname = "Manhusheva"
            };
            userNewspaperMagazine.MaterialSubscribes.Add(typeof(Newspaper), new List<PrintedMaterial> { newspaperList[1] });
            userNewspaperMagazine.MaterialSubscribes.Add(typeof(Magazine), new List<PrintedMaterial> { magazineList[2] });

            return new List<ISubscriber>
            {
                userMagazine, userNewspaper, userMagazineNewspaper, userNewspaperMagazine
            };
        }

        public static List<IDeliveryHandler> GetListOfHandlers()
        {
            IDeliveryHandler onlyMagazineDelivery = new MagazineHandler();
            IDeliveryHandler onlyNewspaperDelivery = new NewspaperHandler();
            IDeliveryHandler MagazineNewspaperDelivery = new MagazineHandler();
            IDeliveryHandler NewspaperMagazineDelivery = new NewspaperHandler();

            MagazineNewspaperDelivery.SetNext(onlyNewspaperDelivery);
            NewspaperMagazineDelivery.SetNext(onlyMagazineDelivery);
            return new List<IDeliveryHandler> 
            {
                onlyMagazineDelivery, onlyNewspaperDelivery, MagazineNewspaperDelivery, NewspaperMagazineDelivery 
            };
        }

        public static void SubscribeUsersToPost(IPublisher publisher, List<ISubscriber> subscribers )
        {
            foreach (var user in subscribers)
            {
                publisher.Subscribe(user);
            }

        }
    }

}
