using System;
using System.Collections.Generic;
using System.Text;

namespace DC_HW_2
{
    public class ProdusedClassFabric : IFabric
    {
        IProdusedClass IFabric.Produse()
        {
            return new ProdusedClass();
        }
    }
}