﻿using Domain.DAL;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Interfaces;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GrillApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : SharedController<Event>
    {
        public EventsController(IRepository<Event> repository, ILogger<EventsController> logger) : base(repository, logger)
        {
        }
    }
}
