﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dtos.Account
{
    public class ResetPassWordResult
    {
        public string Result { get; set; }
        public bool IsSuccess { get; set; }

    }
}
