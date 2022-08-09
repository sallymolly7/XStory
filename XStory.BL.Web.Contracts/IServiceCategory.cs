﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XStory.DTO;

namespace XStory.BL.Web.Contracts
{
    public interface IServiceCategory
    {
        Task<List<Category>> GetCategories();
    }
}
