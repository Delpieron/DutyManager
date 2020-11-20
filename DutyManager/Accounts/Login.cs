using DutyManager.DataBases;
using System;
using System.Collections.Generic;
using System.Text;

namespace DutyManager.Accounts
{
    public class Login
    {
        public DBCreator Context { get; set; }
        public Login(DBCreator context)
        {
            Context = context;
        }

        public bool Verify(string login, string password)
        {
            dbOperations db = new dbOperations(Context);
            //db.Get(context.);
            return true;
        }
    }
}
