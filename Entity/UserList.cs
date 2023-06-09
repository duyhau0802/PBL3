﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.Entity
{
    public class ListUser
    {
        private static ListUser instance;

        private List<User> listAccountUser;
        public List<User> ListAccountUser { get => listAccountUser; set => listAccountUser = value; }
        public static ListUser Instance
        {
            get
            {
                if (instance == null)
                    instance = new ListUser();
                return instance;
            }
            set => instance = value;
        }

        private ListUser()
        {
            listAccountUser = new List<User>();
            listAccountUser.Add(new User("admin", "123", 1));
            listAccountUser.Add(new User("user", "123", 2));

        }

    }
}
