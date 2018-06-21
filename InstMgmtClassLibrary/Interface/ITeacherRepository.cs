using InstMgmtClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary
{
    //Interface for 
    interface ITeacherRepository
    {
        Teacher Get(int id);
    }
}
