﻿using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Helpers;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusinessLayer.Service
{
    public class UserService
    {
        private IUserRepository userRepository;

        public UserService(MedicalDBContext context)
        {
            userRepository = new UserRepository(context);
        }

        public UserModel GetUserByUsernameAndPassword(string username, string password)
        {
            var user = userRepository.GetByUsername(username);


            if (user != null && SecurePasswordHasher.Verify(password, user.Password))
            {
                return new UserModel(user);
            }

            return null;

        }

        public UserModel GetUserById(int id)
        {
            var user = userRepository.GetById(id);
            return new UserModel(user);
        }

        public UserModel CreateUser(string username, string password)
        {
            var saved = userRepository.CreateUser(new User()
            {
                Username = username,
                Password = SecurePasswordHasher.Hash(password),
                RoleId = 2
            });

            return new UserModel(saved);
        }

        public int testMePlease(int x, int y)
        {
            return x * y;
        }

        public UserModel getUserById(int id)
        {
            var user = userRepository.GetById(id);

            if (user != null)
                return new UserModel(user);
            return null;
        }
    }
}
