using System;
using System.Collections.Generic;
using System.Linq;
using WcfUsuarios.Entities;

namespace WcfUsuarios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceUser : IServiceUser
    {
        Data.Entities _entities;

        public ServiceUser()
        {
            _entities = new Data.Entities();
        }

        public void CreateUser(User user)
        {
            try
            {
                _entities.uspCreateUser(user.Name,user.BirthDate,user.Gender);
               
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                _entities.uspDeleteUser(id);

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }

        public List<User> GetUsers()
        {
            List<User> users = null;
            try
            {
                var userData = _entities.uspReadUser().ToList();
                users = userData.Select(s => new User
                {
                    BirthDate = s.birth_date,
                    Gender = s.gender,
                    Id = s.id,
                    Name = s.name
                }).ToList();
            }
            catch(Exception exp)
            {
                throw new Exception(exp.Message);
            }
            return users;
        }

        public User GetUser(int id)
        {
            User user = null;
            try
            {
                var userData = _entities.uspGetUser(id).FirstOrDefault();
                user = new User
                {
                    BirthDate = userData.birth_date,
                    Gender = userData.gender,
                    Id = userData.id,
                    Name = userData.name
                };
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
            return user;
        }

        public void UpdateUser(User user)
        {
            try
            {
                _entities.uspUpdateUser(user.Id,user.Name, user.BirthDate, user.Gender);

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }
    }
}
