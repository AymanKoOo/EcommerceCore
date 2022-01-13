﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels.Order;

namespace Web.Areas.Admin.Factories
{
    public interface IOrderModelFactory
    {
        Task<CheckOut> PrepareCheckOutModel(string Useremail);
    }
}
