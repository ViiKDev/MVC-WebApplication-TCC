using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TccAspNet.Enums
{
    public enum Roles
    {
        SuperAdmin,
        Admin,
        Moderador,
        Basico
    }
}