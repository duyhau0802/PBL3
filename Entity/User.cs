﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.Entity
{
    public class User
    {
        private string userName;
        private string passWord;
        private int accountType;
        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int AccountType { get => accountType; set => accountType = value; }

        public User(string userName, string passWord, int accountType)
        {
            UserName = userName;
            PassWord = passWord;
            AccountType = accountType;
        }

    }
}
