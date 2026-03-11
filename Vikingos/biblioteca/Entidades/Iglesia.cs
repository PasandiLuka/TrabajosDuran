using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblitoteca.Entidades;

public class Iglesia
{
    public float crucifijos { get; set; }

    public double botinCrucifijos()
    {
        return crucifijos * 1.5;
    }
}