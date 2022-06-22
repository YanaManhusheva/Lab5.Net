using Lab5.Pattern3.Abstract;
using Lab5.Pattern3.ConcreteMaterials;
using Lab5.Pattern3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Pattern3.Concrete
{
    public class MagazineHandler : BaseDeliveryHandler
    {
        public override void Handle(PostOffice postOffice, User user)
        {
            var request = user.MaterialSubscribes[typeof(Magazine)];
            foreach(var material in request)
            {
                var printedMaterial = postOffice.PrintedMaterials.OfType<Magazine>()
                    .LastOrDefault(m => m.Name == material.Name);
                if (printedMaterial is not null)
                    postOffice.Deliver(printedMaterial, user);
            }
            base.Handle(postOffice,user);
        }
    }

}
