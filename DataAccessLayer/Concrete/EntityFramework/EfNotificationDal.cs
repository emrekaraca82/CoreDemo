﻿using CoreLayer.Entities.Repositories;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfNotificationDal: GenericRepositoryBase<Notification, Context>, INotificationDal
    {
    }
}
