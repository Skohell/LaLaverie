using LaLaverie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLaverieProject.ViewModel
{
    public class RecetteWindowViewModel
    {
        public BiereModel biere { get; set; }

        public RecetteWindowViewModel(BiereModel b)
        {
            biere = b;
        }
    }
}
