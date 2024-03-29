﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sy.Core.Abstracts
{
  public abstract  class BaseEntity<IKey> : AuditBase, IEntity<IKey>
    {
        [Key]
        public IKey Id { get; set; }
    }
}
