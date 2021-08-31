using System;
using System.Collections.Generic;

namespace MCAT.Controllers
{
    interface IBaseController
    {
        List<Object> GetAll();
        bool Add(Object obj);
        Object GetById(int id);
        bool Update(Object student, String ColumnWidth);
        bool Delete(int id);
    }
}
