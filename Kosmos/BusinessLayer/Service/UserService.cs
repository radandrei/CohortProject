using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Helpers;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.RepositoryInterfaces;
using DataAccessLayer.Repository;

namespace BusinessLayer.Service
{
    public class UserService
    {
        private IUserRepository userRepository;
        private IMedicalChartRepository medicalChartRepository;
        private IPersonRepository personRepository;
        private IPersonalDataRepository personalDataRepository;

        public UserService(MedicalDBContext context)
        {
            userRepository = new UserRepository(context);
            medicalChartRepository = new MedicalChartRepository(context);
            personRepository = new PersonRepository(context);
            personalDataRepository = new PersonalDataRepository(context);
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

        public UserModel CreateUser(string username, string password, int? roleId=null)
        {
            var saved = userRepository.CreateUser(new User()
            {
                Username = username,
                Password = SecurePasswordHasher.Hash(password),
                RoleId = roleId ==null ? 2 : roleId.Value
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

        public List<UserModel> getAllUsers()
        {
            var users = userRepository.GetAll();
            var returnList = users.Select(x => new UserModel(x)).ToList();
            return returnList;
        }

        public void CreatePerson(int userId, int cabinetId, string firstName, string lastName)
        {
            var personalDataId = this.personalDataRepository.AddOrUpdate(new PersonalData() { Birthdate = new DateTime(1999,5,5) }).ID;
            var medicalChartId = this.medicalChartRepository.AddOrUpdate(new MedicalChart() {  CreationDate = DateTime.Today}).ID;


            Person person = new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                Active = true,
                CabinetID = cabinetId,
                UserId = userId,
                MedicalChartID = medicalChartId,
                PersonalDataID = personalDataId
            };

            this.personRepository.AddOrUpdate(person);
        }
    }
}
