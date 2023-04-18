using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CommandsProject.CreateComment
{
    public class CreateProjectCommentCommand : IRequest<Unit>
    {
        public string content { get; set; }
        public int idProject { get; set; }
        public int idUser { get; set; }
    }
}
