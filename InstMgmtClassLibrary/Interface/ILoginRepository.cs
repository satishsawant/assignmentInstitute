using InstMgmtClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Interfaces
{
    public interface ILoginRepository
    {
        string Login(Login log);
    }
}
