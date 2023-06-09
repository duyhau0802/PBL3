﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.Entity
{
    internal class NhanVien
    {
        private int _id;
        private string _name;
        private string _gender;
        private DateTime _dateOfBirth;
        private string _phoneNumber;
        private string _address;
        private string _CCCD;
        private string _email;
        private int _useraccount;

        public NhanVien()
        {
        }

        public NhanVien(int id, string name, string gender, DateTime dateOfBirth, string phoneNumber, string address, string cccd, string email, int user)
        {
            _id = id;
            _name = name;
            _gender = gender;
            _dateOfBirth = dateOfBirth;
            _phoneNumber = phoneNumber;
            _address = address;
            _CCCD = cccd;
            _email = email;
            _useraccount= user;
        }

        public NhanVien(string name, string gender, DateTime dateOfBirth, string phoneNumber, string address, string cccd, string email, int user)
        {
            _name = name;
            _gender = gender;
            _dateOfBirth = dateOfBirth;
            _phoneNumber = phoneNumber;
            _address = address;
            _CCCD = cccd;
            _email = email;
            _useraccount = user;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Gender { get => _gender; set => _gender = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Address { get => _address; set => _address = value; }
        public string CCCD { get => _CCCD; set => _CCCD = value; }
        public string Email { get => _email; set => _email = value; }
        public int Useraccount { get => _useraccount; set => _useraccount = value; }
    }
}
