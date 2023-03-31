using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.InputModels
{
    public class CreatCommentInputModel
    {
        public string content { get; set; }
        public int idProject { get; set; }
        public int idUser { get; set; }
    }
}
