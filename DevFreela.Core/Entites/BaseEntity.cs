using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entites
{

    //Classe abstrata você não consegue instanciala apenas para conter informações que serão reutilizadas. 
    public abstract class BaseEntity 
    {
        protected BaseEntity()
        {

        }
        public int Id { get; private set; }
    }
}
