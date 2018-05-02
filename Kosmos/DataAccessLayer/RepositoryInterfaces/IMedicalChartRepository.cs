using BusinessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.RepositoryInterfaces
{
    interface IMedicalChartRepository: IBaseRepository<MedicalChart>
    {
    }
}
