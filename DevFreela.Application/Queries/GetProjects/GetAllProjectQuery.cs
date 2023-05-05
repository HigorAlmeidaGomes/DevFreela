﻿using DevFreela.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProjects
{
    public class GetAllProjectQuery : IRequest<List<ProjectViewModel>>
    {
    }
}
